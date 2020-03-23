using MediatR;
using Microsoft.Extensions.Options;
using Sms.API.Handlers.Models;
using Sms.API.Helpers;
using Sms.API.Models;
using Sms.Core.Entities;
using Sms.Core.Enums;
using Sms.Domain.Services;
using Sms.Logic.Services;
using Sms.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sms.API.Handlers
{
    public class SendSmsHandler : IRequestHandler<SmsMessage, ResponseSMSModel>
    {
        private readonly IConsumerTokenService _consumerTokenService;
        private readonly IMessageService _messageService;
        private readonly IOperationService _operationService;
        private readonly IOperationSmsProviderService _operationSmsProviderService;
        private readonly ISmsService _smsService;
        private readonly IOptions<AppSettings> _settings;
        private readonly IExceptionsService _exceptionsService;

        public SendSmsHandler(IConsumerTokenService consumerTokenService,         
                              IMessageService messageService,
                              IOperationService operationService,
                              IOperationSmsProviderService operationSmsProviderService,
                              ISmsService smsService,
                              IOptions<AppSettings> settings,
                              IExceptionsService exceptionsService)
        {
            _consumerTokenService = consumerTokenService;
            _messageService = messageService;
            _operationService = operationService;
            _operationSmsProviderService = operationSmsProviderService;
            _smsService = smsService;
            _settings = settings;
            _exceptionsService = exceptionsService;
        }
        public async Task<ResponseSMSModel> Handle(SmsMessage request, CancellationToken cancellationToken)
        {
            try {
          
                var consumerToken = await _consumerTokenService.GetByToken(request.Token);
            
                if (consumerToken.Token == request.Token && consumerToken.Token != null && request.Token != null)
                {
                    if (await _operationService.GetAttempts(request.Phone))
                    {
                        var message = await _messageService.GetById(request.IdMessage, request.IdLanguage);
                        if (String.IsNullOrEmpty(message.Message) || String.IsNullOrEmpty(message.NameFrom) || message.Enable == false)
                            return new ResponseSMSModel { IdStatus = (int)OperationStatus.NOT_FOUND, StatusDescription = "Message template not found in BD" };

                        var provider = await _operationSmsProviderService.GetById(consumerToken.IdProvider);
                        if (String.IsNullOrEmpty(provider.Token))
                            return new ResponseSMSModel { IdStatus = (int)OperationStatus.NOT_FOUND, StatusDescription = "Provider not found in BD" };

                        var newOperation = Mappers.MapNewOperation(request, consumerToken);
                        var sms = Mappers.MapNewMessage(request, message);
                        var configProvider = Mappers.MapNewConfigProvider(provider);

                        var Operation = await _operationService.Add(newOperation);

                        if (!_settings.Value.IsDebug)
                        {
                            Operation.IdStatus = _smsService.SendSMS(sms, configProvider, Operation.Id);
                        }
                        else
                        {
                            Operation.IdStatus = (int)OperationStatus.TEST_API_COMPLETE;
                        }

                        await _operationService.Update(Operation);


                        var response = Mappers.MapNewResponseSMSModel(Operation.IdStatus);

                        response.IdOperation = Operation.Id;
                        response.UrlReturn = request.UrlReturn;
                        return response;
                    }
                    else {
                        var response = Mappers.MapNewResponseSMSModel((int)OperationStatus.ATTEMPTS_EXCEEDED);
                        return response;
                    }
                }
                else
                {
                    var response = Mappers.MapNewResponseSMSModel((int)OperationStatus.UNAUTHORIZED);
                    return response;
                }
            }
            catch (Exception e)
            {
                await _exceptionsService.Publish(e, "SendSmsHandler", "Handle");
                throw e;
            }
        }
    }
}

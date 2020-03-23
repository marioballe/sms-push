using Sms.API.Handlers.Models;
using Sms.API.Models;
using Sms.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sms.API.Helpers
{
    public class Mappers
    {
        public static SmsMessage MapRequest(string token, RequestSMSModel request) {
            return new SmsMessage
            {
                IdObject = request.IdObject,
                IdMessage = request.IdMessage,
                IdLanguage = request.IdLanguage,
                Phone = request.Phone,
                CustomCode = request.CustomCode,
                UrlReturn = request.UrlReturn,
                Token = token
            };
        }

        public static OperationsDTO MapNewOperation(SmsMessage request, ConsumerTokenDTO consumerToken) {
            return new OperationsDTO
            {
                IdPortal = consumerToken.IdPortal,
                IdLanguage = request.IdLanguage,
                IdOrigin = consumerToken.IdApp,
                IdObject = request.IdObject,
                Phone = request.Phone,
                UrlReturn = request.UrlReturn,
                IdStatus = 0,
                IdTemplate = request.IdMessage
            };
        }

        public static SmsDTO MapNewMessage(SmsMessage request, MessagesDTO message)
        {
            string _message = message.Message.Replace(message.CustomCode, request.CustomCode);
            return new SmsDTO()
            {
                From = message.NameFrom,
                Message = _message,
                Phone = request.Phone
            };
        }

        public static ConfigProviderDTO MapNewConfigProvider(OperationSmsProvidersDTO provider)
        {
            return new ConfigProviderDTO()
            {
                Id = provider.Id,
                Token = provider.Token,
                Url = provider.Url
            };
        }

        public static ResponseSMSModel MapNewResponseSMSModel(int _IdStatus) {
            return new ResponseSMSModel()
            {
                IdStatus = _IdStatus,
                StatusDescription = Helpers.GetStatusDescription(_IdStatus)   
            };
        }
    }
}
 
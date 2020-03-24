using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using Sms.Provider.Services;
using Sms.Provider.Models.NSR;
using Sms.Provider.Helpers;
using Sms.Provider.Models;
using Newtonsoft.Json;
using Sms.Provider.Enums;
using Sms.Domain.Services;
using Sms.Core.Enums;
using Sms.Provider.Models.NRS;

namespace Sms.Provider
{
    public class SmsServiceProvider : ISmsServiceProvider
    {
        private readonly IExceptionsService _exceptionsService;
        private readonly IErrorsReportService _errorsReportService;
        public SmsServiceProvider(IExceptionsService exceptionsService,
                                  IErrorsReportService errorsReportService)
        {
            _exceptionsService = exceptionsService;
            _errorsReportService = errorsReportService;
        }
        public int SendSMS(Sms sms, ConfigProvider configProvider, int IdOperation)
        {
            int statusCode = (int)OperationStatus.CREATED;

            try
            {
                // Por defecto usamos el proveedor NSR
                if (configProvider.Id <= 0)
                    configProvider.Id = (int)Providers.NRSGateway;

                switch (configProvider.Id)
                {
                    case (int)Providers.NRSGateway:
                        {
                            statusCode = SendSMS_NRSGateway(sms.From, sms.Phone, sms.Message, configProvider, IdOperation);
                            break;
                        }
                    case (int)Providers.NRS360:
                        {
                            statusCode = SendSMS_NRS360(sms.From, sms.Phone, sms.Message, configProvider, IdOperation);
                            break;
                        }
                    default:
                        {
                            statusCode = (int)OperationStatus.UNKNOWN_PROVIDER;
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                _exceptionsService.Publish(e, "SmsServiceProvider", "SendSMS");
                statusCode = (int)OperationStatus.INTERNAL_API_EXCEPTION;
            }

            return statusCode;
        }

        public int SendSMS_NRSGateway(string nombredesde, string telefono, string mensaje, ConfigProvider configProvider, int IdOperation)
        {
            int _statusCode = (int)OperationStatus.CREATED;

            try
            {
                NrsGatewayRequest sms = new NrsGatewayRequest() { from = nombredesde, text = mensaje, to = new List<string>() { telefono } };
                
                string urlProvider = configProvider.Url;
                string jsonMessage = JsonConvert.SerializeObject(sms);
                string authorization = configProvider.Token;

                var call = new CallWebRequest(_exceptionsService);
                var response = call.SendRequestAsync(urlProvider, jsonMessage, authorization);

                NrsResult result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                        _statusCode = NRSHelper.DecodeStatus(result, (int)SmsStatus.Accepted);
                }
                else {
                    _statusCode = (int)OperationStatus.UNKNOWN;
                    _errorsReportService.Publish(NRSHelper.ErrorsApiReportToDTO(result, (int)Providers.NRSGateway, IdOperation, telefono));
                }
            }
            catch (Exception e)
            {
                _exceptionsService.Publish(e, "SmsServiceProvider", "SendSMS_NRSGateway");
                _statusCode = (int)OperationStatus.INTERNAL_API_EXCEPTION;
            }

            return _statusCode ;
        }

        public int SendSMS_NRS360(string nombredesde, string telefono, string mensaje, ConfigProvider configProvider, int IdOperation)
        {
            int _statusCode = (int)OperationStatus.CREATED;

            try
            {
                Nrs360Request sms = new Nrs360Request() { from = nombredesde, message = mensaje, to = new List<string>() { telefono } };

                string urlProvider = configProvider.Url;
                string jsonMessage = JsonConvert.SerializeObject(sms);
                string authorization = configProvider.Token;

                var call = new CallWebRequest(_exceptionsService);
                var response = call.SendRequestAsync(urlProvider, jsonMessage, authorization);

                NrsResult result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                        _statusCode = NRSHelper.DecodeStatus(result, (int)response.Status);

                        if (result.error != null)
                            _errorsReportService.Publish(NRSHelper.ErrorsSmsReportToDTO(result, (int)Providers.NRSGateway, IdOperation, telefono));
                }
                else
                {
                    _statusCode = (int)OperationStatus.UNKNOWN;
                    _errorsReportService.Publish(NRSHelper.ErrorsApiReportToDTO(result, (int)Providers.NRSGateway, IdOperation, telefono));
                }
            }
            catch (Exception e)
            {
                _exceptionsService.Publish(e, "SmsServiceProvider", "SendSMS_NRS360");
                _statusCode = (int)OperationStatus.INTERNAL_API_EXCEPTION;
            }

            return _statusCode;
        }
    }

}

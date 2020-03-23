using Sms.Domain.Services;
using Sms.Logic.Mappers;
using Sms.Model.DTO;
using Sms.Provider.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Logic.Services
{
    public class SmsService : ISmsService
    {
        private readonly ISmsServiceProvider _smsServiceProvider;
        public SmsService(ISmsServiceProvider smsServiceProvider)
        {
            _smsServiceProvider = smsServiceProvider;
        }
        public int SendSMS(SmsDTO sms, ConfigProviderDTO config, int IdOperation)
        {
            return _smsServiceProvider.SendSMS(MapToModel.SmstToModel(sms), MapToModel.ConfigProviderToModel(config), IdOperation);
        }
    }
}

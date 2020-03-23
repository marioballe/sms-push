using Sms.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Domain.Services
{
    public interface ISmsService
    {
        int SendSMS(SmsDTO sms, ConfigProviderDTO config, int IdOperation);
    }
}

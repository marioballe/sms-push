using Sms.Provider.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Provider.Services
{
    public interface ISmsServiceProvider
    {
        int SendSMS(Sms sms, ConfigProvider config, int IdOperation);
        int SendSMS_NRSGateway(string nombredesde, string telefono, string mensaje, ConfigProvider config, int IdOperation);
        int SendSMS_NRS360(string nombredesde, string telefono, string mensaje, ConfigProvider config, int IdOperation);
    }
}

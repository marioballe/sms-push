using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Provider.Enums
{
    public enum SmsStatus
    {
        Accepted = 202,
        Multistatus = 207,
        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        InternalServerError = 500
    }
}

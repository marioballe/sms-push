using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Provider.Enums
{
    public enum Errors
    {
        NoValidRecipients = 102,
        TextMessageMissing = 104,
        TextMessageTooLong = 105,
        SenderMissing = 106,
        SenderTooTong = 107,
        NoValidDatetimeForSend = 108,
        NotificacionURLincorrect = 109,
        MaximumOrIncorrectPartsAllowed = 110,
        InvalidCoding = 113,
        LoginError = 103,
        IPNotAllowed = 112,
        NoCredits = 111
    }
}

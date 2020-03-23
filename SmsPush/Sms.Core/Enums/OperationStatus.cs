using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Core.Enums
{
    public enum OperationStatus
    {
        OK = 100,
        CREATED = 101,
        BAD_REQUEST = 300,
        UNAUTHORIZED = 301,
        UNKNOWN = 302,
        FORBIDDEN = 303,
        NOT_FOUND = 304,
        ERROR_NUMBER = 306,
        ERROR_SENDER = 305,
        ERROR_MESSAGE = 308,
        ERROR_PROVIDER = 309,
        UNKNOWN_PROVIDER = 307,
        ATTEMPTS_EXCEEDED = 310,
        INTERNAL_API_EXCEPTION = 600,
        TEST_API_COMPLETE = 601
    }
}

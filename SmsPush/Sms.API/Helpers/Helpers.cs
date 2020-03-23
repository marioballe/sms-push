using Sms.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sms.API.Helpers
{
    public class Helpers
    {
        public static string GetStatusDescription(int IdStatus)
        {
            string description = "";

            switch (IdStatus)
            {
                case (int)OperationStatus.OK:
                    description = "ACCEPTED";
                    break;
                case (int)OperationStatus.ERROR_MESSAGE:
                    description = "There was an error with the message, missing or too long.";
                    break;
                case (int)OperationStatus.ERROR_NUMBER:
                    description = "Phone number is not valid.";
                    break;
                case (int)OperationStatus.ERROR_PROVIDER:
                    description = "An error has occurred with the sms provider.";
                    break;
                case (int)OperationStatus.ERROR_SENDER:
                    description = "There was an error with the sender, missing or too long.";
                    break;
                case (int)OperationStatus.INTERNAL_API_EXCEPTION:
                    description = "The Sms.API has had an internal exception.";
                    break;
                case (int)OperationStatus.TEST_API_COMPLETE:
                    description = "TEST SUCCESFULLY. Note: that no SMS has been sent in this test";
                    break;
                case (int)OperationStatus.UNAUTHORIZED:
                    description = "You're UNAUTHORIZED to use this service, check your credentials.";
                    break;
                case (int)OperationStatus.ATTEMPTS_EXCEEDED:
                    description = "The number of attempts for this phone number has been exceeded, try again later";
                    break;
                default:
                    description = "UNKNOWN ERROR!, Please contact with your API provider";
                    break;

            }

            return description;
        }

    }
}

using Sms.Core.Enums;
using Sms.Domain.Services;
using Sms.Model.DTO;
using Sms.Provider.Enums;
using Sms.Provider.Models.NSR;
using Sms.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sms.Provider.Helpers
{
    public static class NRSHelper
    {
        #region Mappers
        public static ErrorsReportDTO ErrorsSmsReportToDTO(NrsResult result, int provider, int _IdOperation, string phone)
        {
            return new ErrorsReportDTO()
            {
                IdDetail = Convert.ToInt32(result.id),
                Phone = phone,
                IdProvider = provider,
                Datetime = DateTime.Now,
                ErrorCode = result.error.code.ToString(),
                ErrorDescription = result.error.description,
                IdOperation = _IdOperation
            };
        }
        public static ErrorsReportDTO ErrorsApiReportToDTO(NrsResult result, int provider, int _IdOperation, string phone)
        {
            return new ErrorsReportDTO()
            {
                IdDetail = Convert.ToInt32(result.id),
                Phone = phone,
                IdProvider = provider,
                Datetime = DateTime.Now,
                ErrorCode = result.error.code.ToString(),
                ErrorDescription = result.error.description,
                IdOperation = _IdOperation
            };
        }
        #endregion

        #region Status managment

        public static int DecodeStatus(NrsResult result, int responseStatus) {
            int _statusCode = 0;

            switch (responseStatus) {
                case 202:
                    _statusCode = (int)OperationStatus.OK;
                    break;
                case 207:
                    _statusCode = (int)OperationStatus.BAD_REQUEST;
                    break;
                case 400:
                        _statusCode = DecodeError(result.error.code);
                    break;
                case 401:
                    _statusCode = (int)OperationStatus.UNAUTHORIZED;
                    break;
                case 402:
                    _statusCode = (int)OperationStatus.FORBIDDEN;
                    break;
                case 500:
                    _statusCode = (int)OperationStatus.ERROR_PROVIDER;
                    break;
                default:
                    _statusCode = (int)OperationStatus.UNKNOWN;
                    break;
            }

            return _statusCode;
        }

        public static int DecodeError(int errorCode) {
            int _errorCode = 0;

            switch (errorCode)
            {
                case 102:
                case 110:
                    _errorCode = (int)OperationStatus.ERROR_NUMBER;
                    break;
                case 104:
                case 105:
                    _errorCode = (int)OperationStatus.ERROR_MESSAGE;
                    break;
                case 106:
                case 107:
                    _errorCode = (int)OperationStatus.ERROR_SENDER;
                    break;
                case 108:
                case 109:
                case 113:
                    _errorCode = (int)OperationStatus.UNKNOWN;
                    break;
                default:
                    _errorCode = (int)OperationStatus.UNKNOWN;
                    break;
            }

            return _errorCode;
        }
        #endregion
    }
}

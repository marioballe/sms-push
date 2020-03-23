using Sms.Model.DTO;
using Sms.Provider.Models;
using Sms.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Logic.Mappers
{
    public class MapToModel
    {
        public static Operations OperationsToModel(OperationsDTO dto)
        {
            return new Operations()
            {
                Id = dto.Id,
                IdBusiness = dto.IdBusiness,
                IdProduct = dto.IdProduct,
                IdPortal = dto.IdPortal,
                IdLanguage = dto.IdLanguage,
                IdOrigin = dto.IdOrigin,
                IdObject = dto.IdObject,
                Phone = dto.Phone,
                CreatedOn = dto.CreatedOn,
                UpdatedOn = dto.UpdatedOn,
                UrlReturn = dto.UrlReturn,
                IdStatus = dto.IdStatus,
                IdTemplate = dto.IdTemplate
            };
        }

        public static ConsumerToken ConsumerTokenToModel(ConsumerTokenDTO dto)
        {
            return new ConsumerToken()
            {
                Id = dto.Id,
                IdApp = dto.IdApp,
                IdPortal = dto.IdPortal,
                IdProvider = dto.IdProvider,
                Token = dto.Token
            };
        }

        public static Sms SmstToModel(SmsDTO dto)
        {
            return new Sms()
            {
                From = dto.From,
                Phone = dto.Phone,
                Message = dto.Message
            };
        }

        public static OperationSmsProviders OperationSmsProvidersToModel(OperationSmsProvidersDTO dto)
        {
            return new OperationSmsProviders()
            {
                Id = dto.Id,
                Name = dto.Name,
                Url = dto.Url,
                Username = dto.Username,
                Password = dto.Password,
                Token = dto.Token
            };
        }

        public static Messages MessagesToModel(Messages dto)
        {
            return new Messages()
            {
                Id = dto.Id,
                IdTemplate = dto.IdTemplate,
                IdLanguage = dto.IdLanguage,
                NameFrom = dto.NameFrom,
                Message = dto.Message,
                Enable = dto.Enable,
                CustomCode = dto.CustomCode
            };
        }

        public static ErrorsReport ErrorsReportToModel(ErrorsReportDTO dto)
        {
            return new ErrorsReport()
            {
                Id = dto.Id,
                Phone = dto.Phone,
                IdProvider = dto.IdProvider,
                Datetime = dto.Datetime,
                ErrorCode = dto.ErrorCode,
                ErrorDescription = dto.ErrorDescription,
                IdOperation = dto.IdOperation
            };
        }

        public static ConfigProvider ConfigProviderToModel(ConfigProviderDTO dto)
        {
            return new ConfigProvider()
            {
                Id = dto.Id,
                Url = dto.Url,
                Token = dto.Token
            };
        }
    }
}

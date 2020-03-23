using Sms.Model.DTO;
using Sms.Provider.Models;
using Sms.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Logic.Mappers
{
    public class MapToDto
    {
        public static OperationsDTO OperationsToDTO(Operations model)
        {
            return new OperationsDTO()
            {
                Id = model.Id,
                IdBusiness = model.IdBusiness,
                IdProduct = model.IdProduct,
                IdPortal = model.IdPortal,
                IdLanguage = model.IdLanguage,
                IdOrigin = model.IdOrigin,
                IdObject = model.IdObject,
                Phone = model.Phone,
                CreatedOn = model.CreatedOn,
                UpdatedOn = model.UpdatedOn,
                UrlReturn = model.UrlReturn,
                IdStatus = model.IdStatus,
                IdTemplate = model.IdTemplate
    };
        }

        public static ConsumerTokenDTO ConsumerTokenToDTO(ConsumerToken model)
        {
            return new ConsumerTokenDTO()
            {
                Id = model.Id,
                IdApp = model.IdApp,
                IdPortal = model.IdPortal,
                IdProvider = model.IdProvider,
                Token = model.Token
            };
        }

        public static SmsDTO SmstToDTO(Sms model) {
            return new SmsDTO()
            {
                From = model.From,
                Phone = model.Phone,
                Message = model.Message
            };
        }

        public static OperationSmsProvidersDTO OperationSmsProvidersToDTO(OperationSmsProviders model) {
            return new OperationSmsProvidersDTO()
            {
                Id = model.Id,
                Name = model.Name,
                Url = model.Url,
                Username = model.Username,
                Password = model.Password,
                Token = model.Token
            };
        }

        public static MessagesDTO MessagesToDTO(Messages model) {
            return new MessagesDTO()
            {
                Id = model.Id,
                IdTemplate = model.IdTemplate,
                IdLanguage = model.IdLanguage,
                NameFrom = model.NameFrom,
                Message = model.Message,
                Enable = model.Enable,
                CustomCode = model.CustomCode
            };
        }

        public static ErrorsReportDTO ErrorsReportToDTO(ErrorsReport model)
        {
            return new ErrorsReportDTO()
            {
                Id = model.Id,
                Phone = model.Phone,
                IdProvider = model.IdProvider,
                Datetime = model.Datetime,
                ErrorCode = model.ErrorCode,
                ErrorDescription = model.ErrorDescription,
                IdOperation = model.IdOperation
            };
        }

        public static ConfigProviderDTO ConfigProviderToDTO(ConfigProviderDTO model)
        {
            return new ConfigProviderDTO()
            {
                Id = model.Id,
                Url = model.Url,
                Token = model.Token
            };
        }
    }
}

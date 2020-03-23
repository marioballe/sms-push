using Sms.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Domain.Services
{
    public interface IOperationSmsProviderService
    {
        Task<OperationSmsProvidersDTO> GetById(int providerId);
    }
}

using Sms.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Domain.Services
{
    public interface IOperationService
    {
        Task<OperationsDTO> Add(OperationsDTO modelStack);
        Task<bool> Update(OperationsDTO modelStack);
        Task<bool> GetAttempts(string phone);
    }
}

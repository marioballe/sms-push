using System;
using System.Threading.Tasks;
using Sms.Repository.Model;

namespace Sms.Reporitory
{
    public interface IOperationRepository
    {
        Task<Operations> Add(Operations model);
        Task<bool> Update(Operations model);
        Task<bool> GetAttempts(string phone);
    }
}

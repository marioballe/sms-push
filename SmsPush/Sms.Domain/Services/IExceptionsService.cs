using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Domain.Services
{
    public interface IExceptionsService
    {
        Task Publish(Exception exception, string className, string methodName);
    }
}

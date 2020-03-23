using Sms.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Repository.Repositories
{
    public interface IExceptionsRepository
    {
        Task Publish(Exception exception, string className, string methodName);
    }
}

using Sms.Domain.Services;
using Sms.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Logic.Services
{
    public class ExceptionsService : IExceptionsService
    {
        private readonly IExceptionsRepository _exceptionsRepository;

        public ExceptionsService(IExceptionsRepository exceptionsRepository) {
            _exceptionsRepository = exceptionsRepository;
        }
        public async Task Publish(Exception exception, string className, string methodName)
        {
            await _exceptionsRepository.Publish(exception, className, methodName);
        }
    }
}

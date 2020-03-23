using Sms.Domain.Services;
using Sms.Logic.Mappers;
using Sms.Model.DTO;
using Sms.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Logic.Services
{
    public class OperationSmsProviderService : IOperationSmsProviderService
    {
        private readonly IOperationSmsProviderRepository _operationSmsProviderRepository;
        public OperationSmsProviderService(IOperationSmsProviderRepository operationSmsProviderRepository)
        {
            _operationSmsProviderRepository = operationSmsProviderRepository;
        }
        public async Task<OperationSmsProvidersDTO> GetById(int modelId)
        {
            return MapToDto.OperationSmsProvidersToDTO(await _operationSmsProviderRepository.GetById(modelId));
        }
    }
}

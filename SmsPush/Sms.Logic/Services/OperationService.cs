using Sms.Domain.Services;
using Sms.Logic.Mappers;
using Sms.Model.DTO;
using Sms.Reporitory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Logic.Services
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationRepository;
        public OperationService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }
        public async Task<OperationsDTO> Add(OperationsDTO modelOperation)
        {
            return MapToDto.OperationsToDTO( await _operationRepository.Add(MapToModel.OperationsToModel(modelOperation)));
        }

        public async Task<bool> Update(OperationsDTO modelOperation)
        {
            return await _operationRepository.Update(MapToModel.OperationsToModel(modelOperation));
        }

        
        public async Task<bool> GetAttempts(string modelPhone)
        {
            return await _operationRepository.GetAttempts(modelPhone);
        }
    }
}

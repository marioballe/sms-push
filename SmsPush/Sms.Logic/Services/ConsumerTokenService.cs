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
    public class ConsumerTokenService : IConsumerTokenService
    {
        private readonly IConsumerTokenRepository _consumerTokenRepository;
        public ConsumerTokenService(IConsumerTokenRepository consumerTokenRepository)
        {
            _consumerTokenRepository = consumerTokenRepository;
        }
        public async Task<ConsumerTokenDTO> GetByToken(string Token)
        {          
            return MapToDto.ConsumerTokenToDTO(await _consumerTokenRepository.GetByToken(Token));           
        }
    }
}

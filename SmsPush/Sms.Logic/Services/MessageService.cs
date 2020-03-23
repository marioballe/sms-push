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
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task<MessagesDTO> GetById(int IdTemplate, int IdLanguage)
        {
            return MapToDto.MessagesToDTO(await _messageRepository.GetById(IdTemplate, IdLanguage));
        }
    }
}

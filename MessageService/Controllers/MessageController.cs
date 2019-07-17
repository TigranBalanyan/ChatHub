using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DbAccessLayer.Entities;
using DbAccessLayer.Models;
using DbAccessLayer.Repository;
using MessageService.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IMessageRepository messageRepository;
        private readonly IMapper mapper;
        public MessageController(IMessageRepository messageRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.messageRepository = messageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] MessageDTO message)
        {
            var newMessage = mapper.Map<MessageDTO, MessageEntity>(message);

            if (await messageRepository.SendMessage(newMessage))
            {
                return Ok();
            }
            else
            {
                BadRequest("Message is not sent");
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IEnumerable<MessageDTO>> ReadMessages(MessageToFrom notif)
        {
            var unreadMessages = await messageRepository.MasseageNotification(notif);
            var unreadMessagesDTO = new List<MessageDTO>();

            foreach (var messageEntity in unreadMessages)
            {
                var messageDTO = new MessageDTO
                {
                    From = messageEntity.From,
                    To = messageEntity.To,
                    MessageText = messageEntity.MessageText
                };

                unreadMessagesDTO.Add(messageDTO);
            }

            return unreadMessagesDTO;
        }

        [Route("read")]
        [HttpPost]
        public async Task MakeMessageRead(MessageToFrom notif)
        {
            await messageRepository.MakeMessageRead(notif);
        }
    }
}

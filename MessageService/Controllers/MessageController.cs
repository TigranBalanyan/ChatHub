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
        public async Task<IActionResult> SendMessage([FromBody] MessageDTO message)
        {
            var newMessage = mapper.Map<MessageDTO, MessageEntity>(message);

            if(await messageRepository.SendMessage(newMessage))
            {
                return Ok();
            }
            else
            {
                BadRequest("Message is not sent");
            }

            return BadRequest();
        }

        public async Task<IEnumerable<MessageDTO>> MessageNotification(MessageToFrom notif)
        {
            var unreadMessages = await messageRepository.MasseageNotification(notif);
            return mapper.Map<IEnumerable<MessageEntity>, IEnumerable<MessageDTO>>(unreadMessages);
        }
    }
}

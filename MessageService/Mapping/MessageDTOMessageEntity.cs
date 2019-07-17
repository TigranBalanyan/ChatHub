using AutoMapper;
using DbAccessLayer.Entities;
using MessageService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Mapping
{
    public class MessageDTOMessageEntity : Profile
    {
        public MessageDTOMessageEntity()
        {
            CreateMap<MessageDTO, MessageEntity>();
            CreateMap<IEnumerable<MessageDTO>, IEnumerable<MessageEntity>>();
        }
    }
}

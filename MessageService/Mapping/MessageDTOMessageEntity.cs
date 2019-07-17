using AutoMapper;
using DbAccessLayer.Entities;
using MessageService.Models;
using System;
using System.Collections.Generic;

namespace MessageService.Mapping
{
    public class MessageDTOMessageEntity : Profile
    {
        public MessageDTOMessageEntity()
        {
            CreateMap<MessageDTO, MessageEntity>();
        }
    }
}

using DbAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbAccessLayer.Models;

namespace DbAccessLayer.Repository
{
    public interface IMessageRepository
    {
        Task<bool> SendMessage(MessageEntity message);
        Task<IEnumerable<MessageEntity>> MasseageNotification(MessageToFrom notif);
        Task MakeMessageRead(MessageToFrom notif);
    }
}

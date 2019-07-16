using DbAccessLayer.Entities;
using DbAccessLayer.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DbAccessLayer.Repository
{
    public interface IMessageRepository
    {
        Task<IEnumerable<MessageEntity>>  GetUserMessages(string from, string to);
        Task SendMessage(MessageEntity message);
        void MakeMessageRead(string from, string to);
    }
}

using DbAccessLayer.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DbAccessLayer.Repository
{
    public interface IMessageRepository
    {
        Task<IEnumerable<MessageDTO>> GetUserMessages(string from, string to);
    }
}

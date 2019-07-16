using DbAccessLayer.Context;
using DbAccessLayer.ModelsDTO;
using DbAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccessLayer.Repository
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MessageDTO>> GetUserMessages(string from, string to)
        {
            return await _context.Messages.Where(message =>((message.From == from && message.To == to) || (message.From == to && message.To == from))).ToListAsync();
        }
    }
}

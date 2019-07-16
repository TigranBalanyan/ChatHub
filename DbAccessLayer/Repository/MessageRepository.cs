using DbAccessLayer.Context;
using DbAccessLayer.Entities;
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

        public async Task<IEnumerable<MessageEntity>> GetUserMessages(string from, string to)
        {
            return await _context.Messages.Where(message =>((message.From == from && message.To == to) || (message.From == to && message.To == from))).ToListAsync();
        }

        public void MakeMessageRead(string from, string to)
        {
            var unreadMessages = _context.Messages.Where(message => message.IsRead == false);
            
        }

        public async Task SendMessage(MessageEntity message)
        {
            using(_context.Messages.AddAsync(message))
            {
                await _context.SaveChangesAsync();
            }
        }
    }
}

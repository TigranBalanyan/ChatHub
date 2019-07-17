using DbAccessLayer.Context;
using DbAccessLayer.Entities;
using DbAccessLayer.Models;
using DbAccessLayer.Entities;
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

        public async Task<IEnumerable<MessageEntity>> MasseageNotification(MessageToFrom notif)
        {
            var unreadMessages = _context.Messages.Where(mess => mess.IsRead == false && mess.To == notif.To && mess.From == notif.From);
            return await unreadMessages.ToListAsync();
        }

        public async Task MakeMessageRead(MessageToFrom notif)
        {
            var unreadMessages = _context.Messages.Where(mess => mess.IsRead == false && mess.To == notif.To && mess.From == notif.From);

            foreach (var message in unreadMessages)
            {
                var messageToChange = _context.Messages.Single(mess => mess == message);
                messageToChange.IsRead = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> SendMessage(MessageEntity message)
        {
            try
            {
                using (_context.Messages.AddAsync(message))
                {
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

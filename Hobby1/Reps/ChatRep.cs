using Hobby1.Data;
using Hobby1.Interfaces;
using Hobby1.Models;
using Microsoft.EntityFrameworkCore;

namespace Hobby1.Reps
{
    public class ChatRep : IRep<Chat, int>
    {
        private readonly AppDbContext context;
        public ChatRep(AppDbContext context)
        {
            this.context = context;
        }
        public async Task Add(Chat entity)
        {
            if (entity == null)
                return;
            await context.Chats.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var chat = await context.Chats.FirstOrDefaultAsync(c => c.Id == id);
            if (chat == null)
                return;
            context.Chats.Remove(chat);
        }

        public async Task<Chat> Get(int id)
        {
            var chat = await context.Chats
                .Include(c => c.Users)
                .Include(c => c.Texts)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (chat == null)
                return null;
            return chat;
        }

        public async Task<IEnumerable<Chat>> GetAll()
        {
            return await context.Chats
                .Include(c => c.Users)
                .Include(c => c.Texts)
                .ToListAsync();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task Update(int id, Chat newEntity)
        {
            if (newEntity == null)
                return;
            var oldChat = await context.Chats
                .Include(c => c.Users)
                .Include(c => c.Texts)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (oldChat == null)
                return;
            oldChat.Title = newEntity.Title;
            oldChat.Users = newEntity.Users;
            oldChat.Texts = newEntity.Texts;
            context.Entry(oldChat).State = EntityState.Modified;
        }
    }
}

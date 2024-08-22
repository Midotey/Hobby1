using Hobby1.Data;
using Hobby1.Interfaces;
using Hobby1.Models;
using Microsoft.EntityFrameworkCore;

namespace Hobby1.Reps
{
    public class TextRep : IRep<Text, int>
    {
        private readonly AppDbContext context;
        public TextRep(AppDbContext context)
        {
            this.context = context;
        }
        public async Task Add(Text entity)
        {
            if (entity == null)
                return;
            await context.Texts.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var text = await context.Texts
                .FirstOrDefaultAsync(t => t.Id == id);
            if (text == null)
                return;
            context.Texts.Remove(text);
        }

        public async Task<Text> Get(int id)
        {
            var text = await context.Texts
                .Include(t => t.Chat)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (text == null)
                return null;
            return text;
        }

        public async Task<IEnumerable<Text>> GetAll()
        {
            return await context.Texts
                .Include(t => t.Chat)
                .ToListAsync();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task Update(int id, Text newEntity)
        {
            if (newEntity == null)
                return;
            var oldT = await context.Texts
                .Include(t => t.Chat)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (oldT == null)
                return;
            oldT.TextData = newEntity.TextData;
            oldT.ChatId = newEntity.ChatId;
            oldT.Chat = newEntity.Chat;
            context.Entry(oldT).State = EntityState.Modified;
        }
    }
}

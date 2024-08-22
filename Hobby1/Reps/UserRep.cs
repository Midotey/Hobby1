using Hobby1.Data;
using Hobby1.Interfaces;
using Hobby1.Models;
using Microsoft.EntityFrameworkCore;

namespace Hobby1.Reps
{
    public class UserRep : IRep<User, string>
    {
        private readonly AppDbContext context;
        public UserRep(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Add(User entity)
        {
            if (entity == null)
                return;
            await context.Users.AddAsync(entity);
        }
        public async Task Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return;
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id.ToLower() == id.ToLower());
            if (user == null)
                return;
            context.Users.Remove(user);
        }
        public async Task<User> Get(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;
            var user = await context.Users
                .Include(u => u.Chats)
                .FirstOrDefaultAsync(u => u.Id.ToLower() == id.ToLower());
            return user;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await context.Users
                .Include(u => u.Chats)
                .ToListAsync();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public async Task Update(string id, User newEntity)
        {
            if (string.IsNullOrEmpty(id) || newEntity == null)
                return;
            var oldUs = await context.Users
                .Include(u => u.Chats)
                .FirstOrDefaultAsync(u => u.Id.ToLower() == id.ToLower());
            if (oldUs == null)
                return;
            oldUs.Name = newEntity.Name;
            oldUs.Age = newEntity.Age;
            oldUs.Gender = newEntity.Gender;
            oldUs.Chats = newEntity.Chats;
            context.Entry(oldUs).State = EntityState.Modified;
        }

    }
}

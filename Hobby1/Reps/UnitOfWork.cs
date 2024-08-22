using Hobby1.Data;
using Hobby1.Interfaces;
using Hobby1.Models;

namespace Hobby1.Reps
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private IRep<User, string> users;
        private IRep<Chat, int> chats;
        private IRep<Text, int> texts;
        public IRep<User, string> Users
        {
            get
            {
                if (users == null)
                    users = new UserRep(context);
                return users;
            }
        }

        public IRep<Chat, int> Chats
        {
            get
            {
                if (chats == null)
                    chats = new ChatRep(context);
                return chats;
            }
        }

        public IRep<Text, int> Texts
        {
            get
            {
                if (texts == null)
                    texts = new TextRep(context);
                return texts;
            }
        }
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

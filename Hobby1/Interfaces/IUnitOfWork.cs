using Hobby1.Models;

namespace Hobby1.Interfaces
{
    public interface IUnitOfWork/*<T>*/ : IDisposable
    {
        IRep<User, string> Users { get; }
        IRep<Chat, int> Chats { get; }
        IRep<Text, int> Texts { get; }
        void SaveChanges();

    }
}

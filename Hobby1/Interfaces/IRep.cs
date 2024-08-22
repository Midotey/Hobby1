namespace Hobby1.Interfaces
{
    public interface IRep<TEntity, TKey>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(TKey id);
        Task Add(TEntity entity);
        Task Delete(TKey id);
        Task Update(TKey id, TEntity newEntity);
        void SaveChanges();
    }
}

namespace YekanPedia.RoboTele.Data.Context
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();

        Database Database { get; }
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}

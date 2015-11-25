namespace YekanPedia.RoboTele.Data.Context
{
    using System.Data.Entity;
    using ManagementSystem.Domain.Entity;

    public class RoboTeleDbContext : DbContext ,IUnitOfWork
    {
        public RoboTeleDbContext()
            : base("name=RoboTeleDbContext")
        {
        }
        public IDbSet<User> User { get; set; }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.BirthDate)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mobile)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Latitude)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Longitude)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Twitter)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Facebook)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Picture)
                .IsUnicode(false);
        }
    }
}

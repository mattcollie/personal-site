using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Profile.Common;
using Profile.Common.Entities;
using Profile.Data.Objects.Objects;

namespace Profile.Data.Access.Context
{
    [DbConfigurationType(typeof(ProfileContextConfiguration))]
    public partial class ProfileContext : DbContext
    {
        public ProfileContext() : base($"name={Constants.DATABASE_CONNECTION_NAME}") { }

        #region Overrides
        public static ProfileContext Create()
        {
            return new ProfileContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Contact>().ToTable("Contacts");
        }

        public new virtual IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            foreach (var entity in ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified)))
            {
                DateTime now = DateTime.UtcNow;
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }
        #endregion

        #region Entities
        public virtual IDbSet<Contact> Contacts { get; set; }
        #endregion
    }
}

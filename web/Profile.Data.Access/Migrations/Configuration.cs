using System.Data.Entity.Migrations;
using Profile.Data.Access.Context;

namespace Profile.Data.Access.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProfileContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        private ProfileContext Context { get; set; }

        protected override void Seed(ProfileContext context)
        {
            Context = context;

            Context.SaveChanges();
        }

        #region Seeds
        

        #endregion
    }
}


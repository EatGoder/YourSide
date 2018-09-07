using Project.API.EntityFramework.Mappings;
using Project.API.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.EntityFramework.DbContext
{
    public class EntityFrameworkDbContext : System.Data.Entity.DbContext
    {
        public EntityFrameworkDbContext()
            : base("name=EntityFrameworkConnection")
        {
            //Database.SetInitializer<EntityFrameworkDbContext>(null);
        }

        public DbSet<UserInfoDataEntity> UserInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserInfoMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}

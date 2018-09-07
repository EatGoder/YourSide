using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Spatial;
using Project.API.EntityFramework.Models;
using Project.API.EntityFramework.Models.Friends;
using Project.API.EntityFramework.Models.VerificationCode;

namespace Project.API.EntityFramework.DbContext
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MySqlDbContext: System.Data.Entity.DbContext
    {
        public MySqlDbContext()
            : base("name=MySqlConnection")
        {
            //Database.SetInitializer<EntityFrameworkDbContext>(null);
        }

        public MySqlDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        public DbSet<UserInfoDataEntity> UserInfo { get; set; }
        public DbSet<FriendDataEntity> FinendInfo { get; set; }
        public DbSet<VerificationCodeDataEntity> VerificationCode { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserInfoDataEntity>().MapToStoredProcedures();
        }
    }
}
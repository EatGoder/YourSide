using Project.API.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.EntityFramework.Mappings
{
    public class UserInfoMapping : EntityTypeConfiguration<UserInfoDataEntity>
    {
        public UserInfoMapping()
        {
            this.HasKey(m => m.UserPhone);

            this.Property(m => m.UserPhone)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(m => m.UserNickName)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(m => m.Password)
                .IsRequired()
                .HasMaxLength(30);

            this.ToTable("UserInfo");

            this.Property(m => m.UserPhone).HasColumnName("UserPhone");
            this.Property(m => m.UserNickName).HasColumnName("UserNickName");
            this.Property(m => m.Password).HasColumnName("Password");
        }
    }
}

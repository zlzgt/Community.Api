using Community.Domain;
using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Reposity.MySql.Map
{
    public class UserMap : IEntityMap<Users>
    {
        /// <summary>
        ///  用户聚合根映射关系
        /// </summary>
        /// <param name="builder"></param>
        public void Map(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Community_Users");
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Id).HasMaxLength(36);

            builder.Property(w => w.UserName).IsRequired();
            builder.Property(w => w.Email);
            builder.Property(w => w.Password).IsRequired();
            builder.Property(w => w.NickName);
            builder.Property(w => w.Tel);
            builder.Property(w => w.AddTime);


         
        }
    }
}

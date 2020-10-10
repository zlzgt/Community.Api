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

            builder.Property(w => w.UserName);
            builder.Property(w => w.Email);
            builder.Property(w => w.Password);
            builder.Property(w => w.NickName);
            builder.Property(w => w.Tel);
            builder.Property(w => w.AddTime);


            // 配置用户一对多的关系 一个用户多个评论
            builder.HasMany(w => w.Comments).WithOne(w => w.User).HasForeignKey(w => w.UserId).OnDelete(DeleteBehavior.Cascade);

            // 配置一个用户对应多篇文章  一对多的关系
            builder.HasMany(w => w.Articles).WithOne(w => w.User).HasForeignKey(w => w.UserId);
        }
    }
}

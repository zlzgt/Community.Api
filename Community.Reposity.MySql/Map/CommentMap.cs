using Community.Domain;
using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Reposity.MySql.Map
{
    public class CommentMap : IEntityMap<Comment>
    {
        /// <summary>
        /// 用户评论映射关系
        /// </summary>
        /// <param name="builder"></param>
        public void Map(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Community_Comment");
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Id).HasMaxLength(36);
            builder.Property(w => w.Content);
            builder.Property(w => w.UserId);
            builder.Property(w => w.ParentId);
            builder.Property(w => w.CommentDate);
            builder.Property(w => w.AddTime);
        }
    }
}

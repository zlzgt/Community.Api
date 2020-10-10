using Community.Domain;
using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Reposity.MySql.Map
{
    /// <summary>
    /// 文章分类映射实体
    /// </summary>
    public class CategoryMap : IEntityMap<Category>
    {
        public void Map(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Community_Category");
            builder.HasKey("Id");
            builder.Property("Title");
            builder.Property("Description");
            builder.Property("AddTime");

            // 一个分类对应多个文章
            builder.HasMany(w => w.Articles).WithOne(w => w.Category).HasForeignKey(w => w.CategoryId);
        }
    }
}

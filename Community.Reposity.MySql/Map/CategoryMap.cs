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
            builder.HasKey(w=>w.Id);
            builder.Property(w => w.Id).HasMaxLength(36);
            builder.Property(w=>w.Title).HasMaxLength(32).IsRequired();
            builder.Property(w=>w.Description);
            builder.Property(w=>w.AddTime);

       
        }
    }
}

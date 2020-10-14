using Community.Domain;
using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Reposity.MySql.Map
{
    public class ArticleMap : IEntityMap<Article>
    {
        public void Map(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Community_Article");
            builder.HasKey(x=>x.Id);
            builder.Property(w => w.Id).HasMaxLength(36);
            builder.Property(w=>w.UserId).IsRequired();
            builder.Property(w=>w.NickName);
            builder.Property(w=>w.Title).IsRequired();
            builder.Property(w=>w.IsDraft).IsRequired();
            builder.Property(w=>w.Content);
            builder.Property(w=>w.Summary);
            builder.Property(w=>w.Img);
            builder.Property(w=>w.Config);
            builder.Property(w=>w.EntryName);
            builder.Property(w=>w.ArticleCategoryJson);
            builder.Ignore(w => w.ArticleCategory);
            builder.Property(w=>w.ReadCount);
            builder.Property(w=>w.Password);
            builder.Property(w=>w.PubTime);
            builder.Property(w=>w.AddTime).IsRequired();

     
        }
    }
}

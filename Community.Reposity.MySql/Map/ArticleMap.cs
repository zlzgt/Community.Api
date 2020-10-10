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
            builder.HasKey("Id");
            builder.Property("UserId");
            builder.Property("NickName");
            builder.Property("Title");
            builder.Property("IsDraft");
            builder.Property("Content");
            builder.Property("Summary");
            builder.Property("Img");
            builder.Property("Config");
            builder.Property("EntryName");
            builder.Property("CategoryId");
            builder.Property("CategoryName");
            builder.Property("ReadCount");
            builder.Property("Password");
            builder.Property("PubTime");
            builder.Property("AddTime");
       
        }
    }
}

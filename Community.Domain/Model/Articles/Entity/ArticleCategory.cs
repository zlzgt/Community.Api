
using EInfrastructure.Core.Config.EntitiesExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Domain.Model.Articles.Entity
{
    /// <summary>
    /// 文章分类 值对象
    /// </summary>
    public class ArticleCategory
    {
        /// <summary>
        /// 分类Id
        /// </summary>
        public string CategoryId { get; set;}
        /// <summary>
        /// 分离标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}

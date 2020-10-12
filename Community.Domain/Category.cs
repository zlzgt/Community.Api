using EInfrastructure.Core.Config.EntitiesExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Community.Domain
{
    /// <summary>
    ///  标签分类
    /// </summary>
    [Table("Category")]
    public partial class Category: AggregateRoot<string>
    {
       
        /// <summary>
        /// 主键
        /// </summary>
        public Category()
        {
            Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 标题
        /// </summary>
        [MaxLength(32),Required]
        public string Title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        ///  一个分类对应多个文章
        /// </summary>
        public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}

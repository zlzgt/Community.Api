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
        public string Title { get; private set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; private set; }

    }
}

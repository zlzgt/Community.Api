
using EInfrastructure.Core.Config.EntitiesExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Community.Domain
{
    /// <summary>
    /// 文章
    /// </summary>
    [Table("Article")]
    public class Article : AggregateRoot<string>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Article()
        {
            Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [MaxLength(256),Required]
        public string Title { get; set; }
        /// <summary>
        /// 是否为草稿
        /// </summary>
        public int IsDraft { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        public string Content { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        [MaxLength(512),Required]
        public string Summary { get; set; }
        /// <summary>
        /// 摘要图片
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 高级选项配置
        /// </summary>
        public string Config { get; set; }
        /// <summary>
        /// 友好地址
        /// </summary>
        public string EntryName { get; set; }
        /// <summary>
        /// 标签Id 多个以逗号分割
        /// </summary>
        [Required]
        public string CategoryId { get; set; }
        /// <summary>
        /// 标签名
        /// </summary>
        [Required]
        public string CategoryName { get; set; }
        /// <summary>
        /// 阅读数量
        /// </summary>
        public int ReadCount { get; set; }
        /// <summary>
        /// 保护密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PubTime { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public virtual Category Category { get; set;}
        /// <summary>
        /// 用户
        /// </summary>
        public virtual Users User { get; set; }
    }
}

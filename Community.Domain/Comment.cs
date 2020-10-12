using EInfrastructure.Core.Config.EntitiesExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Community.Domain
{
    /// <summary>
    /// 评论
    /// </summary>
    [Table("Comment")]
    public class Comment : AggregateRoot<string>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Comment()
        {
            Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 文章Id
        /// </summary>
        public string ArticleId { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        [MaxLength(512),Required]
        public string Content { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 回复Id 没有回复则为0
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime CommentDate { get; set; }
        /// <summary>
        ///  添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
      
        /// <summary>
        /// 用户评论
        /// </summary>
        public virtual Users User { get; set;}

    }
}

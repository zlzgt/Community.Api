using Castle.DynamicProxy.Generators.Emitters;
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
    public class Comment:AggregateRoot<string>
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
        public string ArticleId { get; private set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; private set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; private  set; }
        /// <summary>
        /// 回复Id 没有回复则为0
        /// </summary>
        public int ParentId { get;  private set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime CommentDate { get; private set; }
        /// <summary>
        ///  添加时间
        /// </summary>
        public DateTime AddTime { get; private set; }

        public virtual Article Article { get; private set;}
      

    }
}

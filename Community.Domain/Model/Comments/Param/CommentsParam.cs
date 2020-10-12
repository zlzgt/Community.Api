using Community.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Domain.Model.Comments.Param
{
    /// <summary>
    /// 评论
    /// </summary>
    public  class CommentsParam:PageModel
    {
        /// <summary>
        /// 文章Id
        /// </summary>
        public string ArticleId { get; set; }
    }
}

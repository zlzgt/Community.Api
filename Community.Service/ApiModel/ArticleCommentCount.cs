using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Application.ApiModel
{
    public class ArticleCommentCount
    {
        /// <summary>
        /// 文章Id
        /// </summary>
        public string ArticleId { get; set; }

        /// <summary>
        /// 评论数量
        /// </summary>
        public int CommetCount { get; set; }
    }
}

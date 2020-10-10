using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Application.ApiModel
{
    public class RArticlesModel
    {
        /// <summary>
        /// 发布时间
        /// </summary>
        public string PubTime { get; set; }
        /// <summary>
        ///  添加时间
        /// </summary>
        public string AddTime { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 阅读数量
        /// </summary>
        public int ReadCount { get; set; }

        /// <summary>
        /// 评论数量
        /// </summary>
        public int CommentCount { get; set; }
    }
}

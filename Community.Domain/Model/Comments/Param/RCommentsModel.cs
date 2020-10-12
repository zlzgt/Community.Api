using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Domain.Model.Comments.Param
{
    public class RCommentsModel
    {
        /// <summary>
        /// 评论时间
        /// </summary>
        public string CommentTime { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string CommentContent { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Community.Domain.Model.Comments.Param
{
    public class SubCommentParam
    {
        /// <summary>
        /// 文章Id
        /// </summary>
        public string ArticleId { get; set; }

        /// <summary>
        /// 评论人Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        [Required(ErrorMessage = "评论内容不能为空")]
        public string Content { get; set; }
    }
}

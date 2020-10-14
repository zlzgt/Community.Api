using Community.Domain.Model.Comments.Param;
using Community.Domain.Model.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Domain
{
    /// <summary>
    /// 用户评论
    /// </summary>
    public partial class Comment
    {

        #region 提交评论
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commentRepository"></param>
        /// <param name="subComment"></param>

        public static void SubComment(ICommentRepository commentRepository, SubCommentParam subComment)
        {
            Comment comment = new Comment();
            comment.ArticleId = subComment.ArticleId;
            comment.UserId = subComment.UserId;
            comment.UserName = subComment.UserName;
            comment.Content = subComment.Content;
            comment.CommentDate = DateTime.Now;
            comment.AddTime = DateTime.Now;
            commentRepository.Add(comment);
        }
        #endregion
    }
}

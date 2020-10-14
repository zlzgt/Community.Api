using Community.Domain;
using Community.Infrastructure;
using EInfrastructure.Core.Config.Entities.Data;
using EInfrastructure.Core.Config.Entities.Extensions;
using EInfrastructure.Core.Config.EntitiesExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Community.Api.Models.Comments
{
    /// <summary>
    /// 评论数据传输对象
    /// </summary>
    public class CommentDto
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
        /// 评论用户Id
        /// </summary>
        public string UserId { get; set;}

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserName { get; set; }

        #region 获取评论列表
        /// <summary>
        /// 获取评论列表
        /// </summary>
        /// <param name="articleQuery"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static PageData<CommentDto> GetList(IQuery<Comment, string> articleQuery, Expression<Func<Comment, bool>> func,  PageModel page)
        {
            return articleQuery.GetQueryable().Where(func).Select(w => new CommentDto
            {
                CommentTime = w.CommentDate.ToString("yyyy-MM-dd hh:mm:ss"),
                CommentContent=w.Content,
                UserId=w.UserId,
                UserName=w.UserName
            }).ListPager(page.PageSize, page.PageIndex, true);
        }

        #endregion



    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Community.Api.Models.Comments;
using Community.Domain;
using Community.Domain.Model.Comments.Param;
using Community.Domain.Model.Common.Interfaces;
using Community.Infrastructure;
using EInfrastructure.Core.Config.Entities.Data;
using EInfrastructure.Core.Config.EntitiesExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
namespace Community.Api.Controllers
{
    /// <summary>
    /// 评论
    /// </summary>
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CommentController : Controller
    {

        #region 属性
        private readonly ICommentRepository _commentRepository;

        private readonly IUserRepository _userRepository;

        /// <summary>
        /// 查询评论数据传输对象
        /// </summary>
        private readonly IQuery<Comment, string> _commentQuery;

        protected IServiceProvider ServiceProvider => Request.HttpContext.RequestServices;
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="commentRepository"></param>
        /// <param name="userRepository"></param>
        /// <param name="commentQuery"></param>
        public CommentController(ICommentRepository commentRepository, IUserRepository userRepository,IQuery<Comment,string> commentQuery)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _commentQuery = commentQuery;
        }

        #region 获取评论列表
        /// <summary>
        /// 获取评论列表
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("comments")]
        public ActionResult<ReplyModel> Comments([FromBody]CommentsParam msg)
        {
            ReplyModel reply = new ReplyModel();
            Expression<Func<Comment, bool>> func = w => w.ArticleId == msg.ArticleId;
            PageData<CommentDto> comments=CommentDto.GetList(_commentQuery, func,msg);
            if (comments.Data.Any())
            {
                reply.Status = "002";
                reply.Msg = "获取评论成功";
                reply.Data = comments;
            }
            else
            {
                reply.Msg = "暂时没有评论呢";
            }
            return reply;
        }
        #endregion

        #region 提交评论
        /// <summary>
        /// 提交评论
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("subcomment")]
        public JsonResult SubComment([FromBody]SubCommentParam msg)
        {
            ReplyModel reply = new ReplyModel();
            try
            {
                Comment.SubComment(_commentRepository,msg);
                bool result = ServiceProvider.GetService<IUnitOfWork>().Commit();
                if (result)
                {
                    reply.Status = "002";
                    reply.Msg = "评论成功";
                }
                else
                {
                    reply.Msg = "评论失败";
                }
            }
            catch (Exception ex)
            {
                reply.Msg = $"提交评论出现异常，请重试{ex.Message}";
            }
            return  Json(reply);
        }
        #endregion


    }
}
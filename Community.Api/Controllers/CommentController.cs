
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Community.Domain;
using Community.Domain.Model.Comments.Param;
using Community.Domain.Model.Common.Interfaces;
using Community.Infrastructure;
using EInfrastructure.Core.Config.EntitiesExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
namespace Community.Api.Controllers
{
    /// <summary>
    /// 评论
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        #region 属性
        private readonly ICommentRepository _commentRepository;

        private readonly IUserRepository _userRepository;

        protected IServiceProvider ServiceProvider => Request.HttpContext.RequestServices;
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="commentRepository"></param>
        /// <param name="userRepository"></param>
        public CommentController(ICommentRepository commentRepository, IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }


        #region 获取品论列表
        /// <summary>
        /// 获取评论列表
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [HttpPost("Comments")]
        public ActionResult<ReplyModel> Comments([FromBody]CommentsParam msg)
        {
            ReplyModel reply = new ReplyModel();
            Expression<Func<Comment, bool>> func = w => w.ArticleId == msg.ArticleId;
            PageResult<Comment> comments = _commentRepository.QueryPage<Comment, DateTime>(func, msg.PageSize, msg.PageIndex, w => w.AddTime, false);
            if (comments.DataList.Any())
            {
                List<string> commentsId = comments.DataList.Select(w => w.UserId).Distinct().ToList();

                List<Users> users = _userRepository.GetAll(w => commentsId.Contains(w.Id)).ToList();

                List<RCommentsModel> rComments = new List<RCommentsModel>();
                foreach (var item in comments.DataList)
                {
                    RCommentsModel comment = new RCommentsModel();
                    comment.CommentContent = item.Content;
                    Users user = users.Where(w => w.Id == item.UserId).FirstOrDefault();
                    if (user != null)
                        comment.UserName = user.NickName;
                    comment.CommentTime = item.CommentDate.ToString("yyyy-mm-dd HH:mm:ss");
                    rComments.Add(comment);
                }
                reply.Status = "002";
                reply.Msg = "获取评论成功";
                reply.Data = rComments;
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
        [HttpPost("SubComment")]
        public ActionResult<ReplyModel> SubComment([FromBody]SubCommentParam msg)
        {
            ReplyModel reply = new ReplyModel();
            try
            {
                Comment comment = new Comment();
                comment.ArticleId = msg.ArticleId;
                comment.Content = msg.Content;
                comment.UserId = msg.UserId;
                comment.ParentId = 0;
                comment.CommentDate = DateTime.Now;
                comment.AddTime = DateTime.Now;
                _commentRepository.Set(comment);
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
                reply.Msg = "提交评论出现异常，请重试";
            }
            return reply;
        }
        #endregion


    }
}
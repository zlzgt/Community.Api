using Community.Application.IServices;
using Community.Domain;
using Community.Domain.Model.Common.Interfaces;
using Community.Infrastructure;
using EInfrastructure.Core.Config.EntitiesExtensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using Community.Domain.Model.Articles.Param;
using EInfrastructure.Core.Config.Entities.Data;
using Community.Application.ApiModel;
using Community.Api.Models.Articles;
using Community.Domain.Model.Userers.Event;

namespace Community.Api.Controllers.Articles
{
    /// <summary>
    /// 文章管理
    /// </summary>
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class ArticleController : Controller
    {
        #region 属性
        private readonly IArticleRepository _articleRepository;

        private readonly IUserRepository _userRepository;

        private readonly ICommentRepository _commentRepository;

        /// <summary>
        /// 查询文章数据传输对象
        /// </summary>
        private readonly IQuery<Article, string> _articleQuery;





        protected IServiceProvider ServiceProvider => Request.HttpContext.RequestServices;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="articleRepository">文章仓储</param>
        /// <param name="userRepository">用户仓储</param>
        public ArticleController(IArticleRepository articleRepository, IUserRepository userRepository, ICommentRepository commentRepository, IQuery<Article, string> articleQuery)
        {
            _articleRepository = articleRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
        }
        #endregion

        #region 文章发布或保存草稿
        /// <summary>
        /// 文章发布或保存草稿
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("pubArticle")]
        public JsonResult PubArticle([FromBody] ArticleParam msg)
        {
            ReplyModel reply = new ReplyModel();
            try
            {
                Users users = _userRepository.Get(msg.UserId);
                if (users != null)
                {
                    msg.Password = MD5Encrypt.Encrypt(msg.Password);
                    Article.Add(_articleRepository, msg);
                    UserArticleEventExtend.TriggerAlterUserAritlceCountEvent(users,ServiceProvider);
                    bool result = ServiceProvider.GetService<IUnitOfWork>().Commit();
                    if (result)
                    {
                        reply.Status = "002";
                        reply.Msg = "保存文章成功";
                    }
                    else
                    {
                        reply.Msg = "保存文章失败";
                    }
                }
                else
                {
                    reply.Msg = "未找到用户信息";
                }
            }
            catch (Exception ex)
            {
                reply.Msg = "文章发布或保存草稿失败，请重试";
                // _Logger.LogError($"文章发布或保存草稿失败，请重试{JsonConvert.SerializeObject(ex)}");
            }
            return Json(reply);
        }
        #endregion

        #region 获取文章列表
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("articles")]
        public  JsonResult Articles([FromBody] PageModel msg)
        {
            ReplyModel reply = new ReplyModel();
            PageData<ArticleDto> articles = ArticleDto.GetList(_articleQuery, msg);
            if (articles.Data.Any())
            {
          
                reply.Status = "002";
                reply.Msg = "获取数据成功";
                reply.Data = articles;
            }
            else
            {
                reply.Msg = "没有数据了";
            }
            return Json(reply);
        }
        #endregion

        #region 获取文章详情
        /// <summary>
        /// 获取文章详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("articleDetail")]
        public JsonResult  ArticleDetail(string id)
        {
            ReplyModel reply = new ReplyModel();
            Article article=  Article.ArticleDetail(_articleRepository, id);
            ServiceProvider.GetService<IUnitOfWork>().Commit();
            if (article!=null)
            {
                reply.Status = "002";
                reply.Msg = "获取数据成功";
                reply.Data = article;
            }
            else
            {
                reply.Msg = "未找到文章详情";
            }
            return Json(reply);
        }
        #endregion

    }
}

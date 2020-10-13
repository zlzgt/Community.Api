using Community.Application.ApiModel;
using Community.Application.IServices;
using Community.Domain;
using Community.Domain.Model.Common.Interfaces;
using Community.Infrastructure;
using EInfrastructure.Core.Config.EntitiesExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace Community.Api.Controllers
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


        private readonly IArticleService _articleService;


        private readonly ICommentRepository _commentRepository;

        private readonly IQuery<Article, string> _articleQuery;





        protected IServiceProvider ServiceProvider => Request.HttpContext.RequestServices;
        #endregion
        #region 构造函数
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="articleRepository">文章仓储</param>
        /// <param name="userRepository">用户仓储</param>
        public ArticleController(IArticleRepository articleRepository, IUserRepository userRepository,ICommentRepository commentRepository, IQuery<Article,string> articleQuery,IArticleService articleService)
        {
            _articleRepository = articleRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            _articleQuery = articleQuery;
            _articleService = articleService;
        }
        #endregion


        #region 文章发布或保存草稿
        /// <summary>
        /// 文章发布或保存草稿
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("pubArticle")]
        //[Authorize]
        public ActionResult<ReplyModel> PubArticle([FromBody] PubArticleModel msg)
        {
            ReplyModel reply = new ReplyModel();
            try
            {
                Users users = _userRepository.Get(msg.UserId);
                if (users != null)
                {
                    Article article = new Article();
                    article.UserId = msg.UserId;
                    article.NickName = users.NickName;
                    article.Title = msg.Title;
                    article.IsDraft = msg.IsDraft;
                    article.Content = msg.Content;
                    article.Summary = msg.Summary;
                    article.Img = msg.Img;
                    article.Config = msg.AdvancedOptions;
                    article.EntryName = msg.EntryName;
                    article.CategoryId = msg.TagId;
                    article.CategoryName = msg.TagName;
                    article.ReadCount = 0;
                    article.Password = MD5Encrypt.Encrypt(msg.Password);
                    article.PubTime = DateTime.Now;
                    article.AddTime = DateTime.Now;
                    _articleRepository.Set(article);
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
            return reply;
        }
        #endregion

        #region 获取文章列表
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("articles")]
        public ActionResult<ReplyModel> Articles([FromBody] PageModel msg)
        {
            return _articleService.Articles(msg);
            ReplyModel reply = new ReplyModel();
            try
            {
                PageResult<Article> articles = _articleRepository.QueryPage<Article, DateTime>(w => true, msg.PageSize, msg.PageIndex, w => w.AddTime, false);
                if (articles.DataList.Any())
                {
                    List<string> articlesId = articles.DataList.Select(w => w.Id).ToList();
                    List<Comment> comments = _commentRepository.GetAll(w => articlesId.Contains(w.Id)).ToList();
                    List<RArticlesModel> rArticles = new List<RArticlesModel>();
                    foreach (var item in articles.DataList)
                    {
                        RArticlesModel rArticle = new RArticlesModel();
                        rArticle.PubTime = item.PubTime.ToString("yyyy年MM月dd日");
                        rArticle.AddTime = item.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
                        rArticle.Summary = item.Summary;
                        rArticle.Username = item.NickName;
                        rArticle.ReadCount = item.ReadCount;
                        rArticle.CommentCount = comments.Where(w => w.ArticleId == item.Id).Count();
                        rArticles.Add(rArticle);
                    }
                    reply.Status = "002";
                    reply.Msg = "获取数据成功";
                    reply.Data = articles;
                }
                else
                {
                    reply.Msg = "没有数据了";
                }

            }
            catch (Exception ex)
            {
                reply.Msg = "获取文章列表出现异常";
                //  _Logger.LogError($"获取文章列表出现异常{JsonConvert.SerializeObject(ex)}");
            }
            return reply;
        }
        #endregion

        #region 获取文章详情
        /// <summary>
        /// 获取文章详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("detail")]
        public ActionResult<ReplyModel> ArticleDetail(string id)
        {
            ReplyModel reply = new ReplyModel();
            Expression<Func<Article, bool>> func = w => w.Id == id;
            Article article = _articleRepository.Get(func);
            if (article != null)
            {
                article.ReadCount += 1;
                bool result = ServiceProvider.GetService<IUnitOfWork>().Commit();
                if (result)
                {
                    reply.Status = "002";
                    reply.Msg = "获取数据成功";
                    reply.Data = article;
                }
                else
                {
                    reply.Msg = "添加阅读量失败";
                }
            }
            else
            {
                reply.Msg = "未找到文章详情";
            }
            return reply;
        }
        #endregion


        //#region 测试数据传输对象
        //[HttpGet("GetList1")]
        
        //public JsonResult GetList()
        //{

        //    return Json(ArticlesDto.GetList(_articleQuery));
        //}
        //#endregion


    }
}

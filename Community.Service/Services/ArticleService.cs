using Community.Application.ApiModel;
using Community.Application.IServices;
using Community.Domain;
using Community.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Community.Application.Services
{
    public class ArticleService
    {

        //private readonly CommunityDbContext _CommunityDbContext;
        ///// <summary>
        ///// 构造函数注入
        ///// </summary>
        //public ArticleService(CommunityDbContext dbContext)
        //{
        //    this._CommunityDbContext = dbContext;
        //}

        //public ReplyModel Articles(PageModel msg)
        //{
        //    throw new NotImplementedException();
        //}

        //public ReplyModel PubArticle(PubArticleModel msg)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// 文章发布或保存草稿
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        //public  ReplyModel PubArticle(PubArticleModel msg)
        //{
        //    ReplyModel reply = new ReplyModel();
        //    try
        //    {
        //        Users users = _CommunityDbContext.Set<Users>().Where(w => w.Id == msg.UserId).FirstOrDefault();
        //        if (users != null)
        //        {
        //            Article article = new Article();
        //            article.UserId = msg.UserId;
        //            article.NickName = users.NickName;
        //            article.Title = msg.Title;
        //            article.IsDraft = msg.IsDraft;
        //            article.Content = msg.Content;
        //            article.Summary = msg.Summary;
        //            article.Img = msg.Img;
        //            article.Config = msg.AdvancedOptions;
        //            article.EntryName = msg.EntryName;
        //            article.CategoryId = msg.TagId;
        //            article.CategoryName = msg.TagName;
        //            article.ReadCount = 0;
        //            article.Password = MD5Encrypt.Encrypt(msg.Password);
        //            article.PubTime = DateTime.Now;
        //            article.AddTime = DateTime.Now;
        //            _CommunityDbContext.Set<Article>().Add(article);
        //            int iResult = _CommunityDbContext.SaveChanges();
        //            if (iResult > 0)
        //            {
        //                reply.Status = "002";
        //                reply.Msg = "保存文章成功";
        //            }
        //            else
        //            {
        //                reply.Msg = "保存文章失败";
        //            }
        //        }
        //        else
        //        {
        //            reply.Msg = "未找到用户信息";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        reply.Msg = "文章发布或保存草稿失败，请重试";
        //       // _Logger.LogError($"文章发布或保存草稿失败，请重试{JsonConvert.SerializeObject(ex)}");
        //    }
        //    return reply;
        //}



        #region 获取文章列表
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <returns></returns>
        //public ReplyModel Articles(PageModel msg)
        //{
        //    ReplyModel reply = new ReplyModel();
        //    try
        //    {
        //        List<Article> articles = _CommunityDbContext.Set<Article>().OrderByDescending(w => w.Id).Skip((msg.PageIndex - 1) * msg.PageSize).Take(msg.PageSize).ToList();
        //        if (articles.Any())
        //        {
        //            List<int> articlesId = articles.Select(w => w.Id).ToList();
        //            List<Comment> comments = _CommunityDbContext.Set<Comment>().Where(w => articlesId.Contains(w.Id)).ToList();
        //            List<RArticlesModel> rArticles = new List<RArticlesModel>();
        //            foreach (var item in articles)
        //            {
        //                RArticlesModel rArticle = new RArticlesModel();
        //                rArticle.PubTime = item.PubTime.ToString("yyyy年MM月dd日");
        //                rArticle.AddTime = item.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
        //                rArticle.Summary = item.Summary;
        //                rArticle.Username = item.NickName;
        //                rArticle.ReadCount = item.ReadCount;
        //                rArticle.CommentCount = comments.Where(w => w.ArticleId == item.Id).Count();
        //                rArticles.Add(rArticle);
        //            }
        //            reply.Status = "002";
        //            reply.Msg = "获取数据成功";
        //            reply.Data = rArticles;
        //        }
        //        else
        //        {
        //            reply.Msg = "没有数据了";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        reply.Msg = "获取文章列表出现异常";
        //      //  _Logger.LogError($"获取文章列表出现异常{JsonConvert.SerializeObject(ex)}");
        //    }
        //    return reply;
        //}
        #endregion

        //#region 获取文章详情
        ///// <summary>
        ///// 文章详情
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult<ReplyModel> ArticleDetail(int id)
        //{
        //    ReplyModel reply = new ReplyModel();
        //    try
        //    {
        //        CArticle article = _CommunityForumContext.Set<CArticle>().Where(w => w.Id == id && w.IsDraft == 1).FirstOrDefault();
        //        if (article != null)
        //        {
        //            article.ReadCount += 1;
        //            int iResult = _CommunityForumContext.SaveChanges();
        //            reply.Data = article;
        //            if (iResult > 0)
        //            {
        //                reply.Status = "002";
        //                reply.Msg = "获取数据成功";
        //            }
        //            else
        //            {
        //                reply.Msg = "添加阅读量失败";
        //            }
        //        }
        //        else
        //        {
        //            reply.Msg = "未找到文章详情";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        reply.Msg = "获取文章详情，出现异常";
        //        _Logger.LogError($"获取文章详情，出现异常{JsonConvert.SerializeObject(ex)}");
        //    }
        //    return reply;
        //}
        //#endregion
    }
}

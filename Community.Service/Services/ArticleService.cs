using Community.Application.ApiModel;
using Community.Application.Dapper;
using Community.Application.IServices;
using Community.Domain;
using Community.Infrastructure;
using Community.Reposity.MySql;
using Dapper;
using EInfrastructure.Core.Config.Entities.Data;
using EInfrastructure.Core.Config.EntitiesExtensions;
using EInfrastructure.Core.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Community.Application.Services
{
    /// <summary>
    /// 文章服务
    /// </summary>
    public class ArticleService : IArticleService
    {

        #region 属性
        /// <summary>
        /// 查询文章
        /// </summary>
        private readonly IQuery<Article, string> _articleQuery;

        private readonly CommunityDbContext _communityDbContext;
        #endregion
        public ArticleService(IQuery<Article,string> articleQuery,CommunityDbContext communityDbContext)
        {
            _articleQuery = articleQuery;
            _communityDbContext = communityDbContext;
        }

        #region 获取文章列表
        public ReplyModel Articles(PageModel msg)
        {

            ReplyModel reply = new ReplyModel();
           
            PageData<ArticlesDto>  articles = ArticlesDto.GetList(_articleQuery,msg); 
            if (articles.Data.Any())
            {
                List<string> articlesId = articles.Data.Select(w => w.Id).ToList();

                    string mySql = $@"select ArticleId ,COUNT(ArticleId) as CommetCount
                                   from community_comment
                                   where Id in {articlesId} 
                                   GROUP BY ArticleId";
                    var articleComments = _communityDbContext.SqlQuery<ArticleCommentCount>(mySql).ToList();
                    List<RArticlesModel> rArticles = new List<RArticlesModel>();
                    foreach (var item in articles.Data)
                    {
                        RArticlesModel rArticle = new RArticlesModel();
                        rArticle.PubTime = item.PubTime;
                        rArticle.AddTime = item.AddTime;
                        rArticle.Summary = item.Summary;
                        rArticle.Username = item.UserName;
                        rArticle.ReadCount = item.ReadCount;
                        if(articleComments.Exists(w=>w.ArticleId==item.Id))
                        rArticle.CommentCount = articleComments.Where(w => w.ArticleId == item.Id).FirstOrDefault().CommetCount;
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
            return reply;
        }
        #endregion




        public ReplyModel PubArticle(PubArticleModel msg)
        {
            throw new NotImplementedException();
        }
    }
}

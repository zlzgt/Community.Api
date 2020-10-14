using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Community.Domain.Model.Articles.Param;
using Community.Domain.Model.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Community.Domain
{
    public partial class Article
    {


        #region 添加文章
        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="articleParam"></param> 
        public static void Add(IArticleRepository articleRepository, ArticleParam articleParam)
        {
            Article article = new Article();
            article.UserId = articleParam.UserId;
            article.NickName = articleParam.NickName;
            article.Title = articleParam.Title;
            article.IsDraft = articleParam.IsDraft;
            article.Content = articleParam.Content;
            article.Summary = articleParam.Summary;
            article.Img = articleParam.Img;
            article.Config = articleParam.Config;
            article.EntryName = articleParam.EntryName;
            article.ArticleCategory = articleParam.ArticleCategory;
            article.ReadCount = 0;
            article.Password = articleParam.Password;
            article.PubTime = DateTime.Now;
            article.AddTime = DateTime.Now;
            articleRepository.Set(article);
        }
        #endregion


        #region 修改文章阅读数量并返回详情
        /// <summary>
        /// 修改文章阅读数量并返回详情
        /// </summary>
        /// <param name="articleRepository"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public  static Article ArticleDetail(IArticleRepository articleRepository ,string id)
        {
            Expression<Func<Article, bool>> func = w => w.Id == id;
            Article article = articleRepository.Get(func);
            if(article!=null)
            {
                article.ReadCount += 1;
            }
            return article;
        }
        #endregion

    }
}

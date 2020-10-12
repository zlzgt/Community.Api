using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Community.Domain.Model.Common.Interfaces;
using Community.Infrastructure;
using EInfrastructure.Core.Config.EntitiesExtensions;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Community.Domain
{
    /// <summary>
    /// 文章
    /// </summary>
    public partial class Article
    {


        #region 获取文章信息
        /// <summary>
        /// 获取文章信息
        /// </summary>
        /// <param name="articleRepository"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Article Get(IArticleRepository articleRepository , Expression<Func<Article,bool>>func)
        {
            return articleRepository.Get(func);
        }
        #endregion


        #region 分页获取文章数据
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="funcWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="funcOrderby"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public static PageResult<Article> QueryPage(IArticleRepository articleRepository ,Expression<Func<Article,bool>> funcWhere ,int pageSize ,int pageIndex, Expression<Func<Article,DateTime>> funcOrderby,bool isAsc=true)
        {
            return articleRepository.QueryPage<Article, DateTime>(funcWhere,pageSize,pageIndex,funcOrderby,isAsc);
        }
        #endregion


        #region 设置文章信息
        /// <summary>
        /// 设置文章信息
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public static bool Set(IArticleRepository articleRepository, Article article)
        {
            return articleRepository.Set(article);
        }
        #endregion


    }
}

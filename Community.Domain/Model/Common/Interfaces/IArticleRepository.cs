using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Community.Infrastructure;
using EInfrastructure.Core.Config.EntitiesExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Community.Domain.Model.Common.Interfaces
{
    /// <summary>
    /// 获取文章信息
    /// </summary>
    public interface IArticleRepository:IRepository<Article,string>
    {
        /// <summary>
        /// 获取文章信息
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
         Article Get(Expression<Func<Article, bool>> func);

        /// <summary>
        /// 设置文章信息
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        bool Set(Article article);
        /// <summary>
        /// 分页获取文章列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="funcWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="funcOrderby"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOrderby, bool isAsc = true) where T : class;


    }
}

using Community.Domain;
using Community.Domain.Model.Comments.Param;
using Community.Domain.Model.Common.Interfaces;
using Community.Domain.Model.Userers.Param;
using Community.Infrastructure;
using EInfrastructure.Core.Config.EntitiesExtensions;
using EInfrastructure.Core.Configuration.Ioc;
using EInfrastructure.Core.MySql.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Community.Reposity.MySql.Infrastructure.Common
{
    public class ArticleRepository : RepositoryBase<Article, string>, IArticleRepository, IPerRequest
    {

        public ArticleRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
        #region 获取文章信息
        /// <summary>
        /// 获取文章信息
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public Article Get(Expression<Func<Article, bool>> func)
        {
            return base.Dbcontext.Set<Article>().Where(func).FirstOrDefault();
        }
        #endregion

        #region 分页获取数据
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
        public PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOrderby, bool isAsc = true) where T : class
        {
            var list = (IQueryable<T>)base.Dbcontext.Set<T>();
            if (funcWhere != null)
            {
                list = list.Where<T>(funcWhere);
            }
            if (isAsc)
            {
                list = list.OrderBy(funcOrderby);
            }
            else
            {
                list = list.OrderByDescending(funcOrderby);
            }
            PageResult<T> result = new PageResult<T>()
            {
                DataList = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount =base.Dbcontext.Set<T>().Count(funcWhere)
            };
            return result;
        }
        #endregion

        #region 设置文章信息
        /// <summary>
        /// 设置文章信息
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public bool Set(Article article)
        {
            base.Dbcontext.Set<Article>().Add(article);
            return true;
        }
        #endregion


    

    }
}

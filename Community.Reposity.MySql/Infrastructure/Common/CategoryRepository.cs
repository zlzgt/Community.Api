using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Community.Domain;
using Community.Domain.Model.Common.Interfaces;
using Community.Infrastructure;
using EInfrastructure.Core.Config.EntitiesExtensions;
using EInfrastructure.Core.Configuration.Ioc;
using EInfrastructure.Core.MySql.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;

namespace Community.Reposity.MySql.Infrastructure.Common
{
    public class CategoryRepository : RepositoryBase<Category, string>, ICategoryRepository, IPerRequest
    {

        public CategoryRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
        #region 设置分类信息
        /// <summary>
        /// 设置分类信息
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool Set(Category category)
        {
            base.Dbcontext.Set<Category>().Add(category);
            return true;
        }
        #endregion

        #region 获取分类信息
        /// <summary>
        /// 获取分类信息
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public Category Get(Expression<Func<Category,bool>> func)
        {
            return base.Dbcontext.Set<Category>().Where(func).FirstOrDefault();
        }
        #endregion

        #region 获取标题列表
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
                TotalCount = base.Dbcontext.Set<T>().Count(funcWhere)
            };
            return result;
        }
        #endregion

    }
}

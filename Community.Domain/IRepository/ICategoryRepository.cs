using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Community.Infrastructure;
using EInfrastructure.Core.Config.EntitiesExtensions;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Text;

namespace Community.Domain.Model.Common.Interfaces
{
    public interface ICategoryRepository:IRepository<Category, string>
    {
        /// <summary>
        /// 设置分类标题
        /// </summary>                                                                                                                                                                             
        /// <param name="category"></param>
        /// <returns></returns>
        bool Set(Category category);

        /// <summary>
        /// 获取分类信息
        /// </summary>
        /// <param name="funcs"></param>
        /// <returns></returns>
        Category Get(Expression<Func<Category, bool>> funcs);

        /// <summary>
        /// 分页获取标题列表
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

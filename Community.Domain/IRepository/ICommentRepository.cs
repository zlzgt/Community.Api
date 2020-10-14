using Community.Infrastructure;
using EInfrastructure.Core.Config.EntitiesExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Community.Domain.Model.Common.Interfaces
{
    public interface ICommentRepository :IRepository<Comment, string>
    {
        /// <summary>
        /// 设置评论
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        bool Set(Comment comment);

        /// <summary>
        /// 分页获取评论列表
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

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<Comment> GetAll(Expression<Func<Comment, bool>> where = null);

    }
}

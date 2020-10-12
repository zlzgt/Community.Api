using Community.Domain;
using Community.Domain.Model.Common.Interfaces;
using Community.Infrastructure;
using EInfrastructure.Core.Config.EntitiesExtensions;
using EInfrastructure.Core.Configuration.Ioc;
using EInfrastructure.Core.MySql.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Community.Reposity.MySql.Infrastructure.Common
{
    public class CommentRepository : RepositoryBase<Comment, string>, ICommentRepository, IPerRequest
    {

        public CommentRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
        #region 提交评论
        /// <summary>
        /// 提交评论
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public bool Set(Comment comment)
        {
            base.Dbcontext.Set<Comment>().Add(comment);
            return true;
        }
        #endregion


        #region 获取评论列表
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


        /// <summary>
        ///  获取所有评论信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IQueryable<Comment> GetAll(Expression<Func<Comment, bool>> where = null)
        {
            return base.Dbcontext.Set<Comment>().Where(where);
        }
    }
}

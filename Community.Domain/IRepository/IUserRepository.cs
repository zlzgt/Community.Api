using Community.Domain.Model.Userers.Param;
using EInfrastructure.Core.Config.EntitiesExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Community.Domain.Model.Common.Interfaces
{
    /// <summary>
    /// 获取用户信息仓储接口
    /// </summary>
    public interface IUserRepository : IRepository<Users, string>
    {
        /// <summary>
        ///  获取用户信息仓储模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         Users Get(string  id); 

        /// <summary>
        /// 根据用户账号和密码获取用户信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
         Users Get(LoginParam param);

        /// <summary>
        /// 根据Lamada表达式进行查询
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        Users Get(Expression<Func<Users,bool>> func);

        /// <summary>
        /// 设置用户信息仓储模型
        /// </summary>
        /// <returns></returns>
        Boolean Set(Domain.Users users);

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<Users> GetAll(Expression<Func<Users, bool>> where = null);

        /// <summary>
        ///  获取用户列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters) where T : class, new();

    }
}

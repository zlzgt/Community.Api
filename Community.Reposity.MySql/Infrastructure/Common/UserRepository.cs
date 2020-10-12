using Community.Domain;
using Community.Domain.Model.Common.Interfaces;
using EInfrastructure.Core.Config.EntitiesExtensions;
using EInfrastructure.Core.Configuration.Ioc;
using EInfrastructure.Core.MySql.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core.Records.NotUsed;
using System.Linq;
using Community.Domain.Model.Userers.Param;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using System.Linq.Expressions;
using Pomelo.EntityFrameworkCore.MySql.Query.ExpressionVisitors.Internal;

namespace Community.Reposity.MySql.Infrastructure.Common
{
    /// <summary>
    ///用户信息仓储
    /// </summary>
    public class UserRepository : RepositoryBase<Users, string>, IUserRepository, IPerRequest
    {

        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        /// <summary>
        /// 根据用户Id获取用户信息
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns></returns>
        public Domain.Users Get(string id)
        {
            var users = base.Dbcontext.Set<Users>().Where(w => w.Id == id).FirstOrDefault();
            return users;
        }
        /// <summary>
        /// 根据用户账号和密码获取用户信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Domain.Users Get(LoginParam param)
        {
            var user = base.Dbcontext.Set<Users>().Where(w => w.UserName == param.UserName && w.Password == param.Password).FirstOrDefault();
            return user;
        }
        /// <summary>
        /// 根据lamada表达查询
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public Users Get(Expression<Func<Users, bool>> func)
        {
            var user = base.Dbcontext.Set<Users>().Where(func).FirstOrDefault();
            return user;
        }
        /// <summary>
        ///  获取所有用户信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IQueryable<Users> GetAll(Expression<Func<Users, bool>> where = null)
        {
            return base.Dbcontext.Set<Users>().Where(where);
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public Boolean Set(Domain.Users users)
        {
            base.Dbcontext.Set<Users>().Add(users);
            return true;
        }

        /// <summary>
        /// Sql语句获取用户信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters) where T : class, new()
        {
            return base.Dbcontext.Database.SqlQuery<T>(sql, parameters);
        }

    }
}

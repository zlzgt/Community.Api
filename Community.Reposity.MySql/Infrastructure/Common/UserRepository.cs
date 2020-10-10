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
        ///  设置用户信息
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public bool Set(Users users)
        {
            return true;
        }


    }
}

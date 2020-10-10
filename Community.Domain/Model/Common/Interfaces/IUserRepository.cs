using Community.Domain.Model.Userers.Param;
using EInfrastructure.Core.Config.EntitiesExtensions;
using System;
using System.Collections.Generic;
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
        /// 设置用户信息仓储模型
        /// </summary>
        /// <returns></returns>
        Boolean Set(Domain.Users users);





    }
}

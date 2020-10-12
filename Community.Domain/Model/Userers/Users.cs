using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Community.Domain.Model.Common.Interfaces;
using Community.Domain.Model.Userers.Param;
using Community.Infrastructure;
using EInfrastructure.Core.Config.EntitiesExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Community.Domain
{
    public partial class Users
    {
        #region 获取用户信息
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static Users Get(IUserRepository userRepository, LoginParam param)
        {
            return userRepository.Get(param);
        }
        #endregion


        #region 获取用户信息
        /// <summary>
        /// 根据用户id获取用户信息
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Users Get(IUserRepository userRepository, string id)
        {
            return userRepository.Get(id);
        }
        #endregion

        #region 根据lamada表达式获取用户信息 
        /// <summary>
        /// 根据lamada表达式获取用户信息
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Users Get(IUserRepository userRepository, Expression<Func<Users, bool>> func)
        {
            return userRepository.Get(func);
        }
        #endregion


        #region 用户注册信息
        /// <summary>
        /// 注册用户信息
        /// </summary>
        /// <returns></returns>
        public static bool Register(IUserRepository userRepository, string userName, string email, string password, string nickName, string Tel)
        {
            Users user = new Users();
            user.AddTime = DateTime.Now;
            user.Email = email;
            user.NickName = nickName;
            user.Password = MD5Encrypt.Encrypt(password);
            user.Tel = Tel;
            user.UserName = userName;
            return userRepository.Set(user);
        }
        #endregion



 




    }
}

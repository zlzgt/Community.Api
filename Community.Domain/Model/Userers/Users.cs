using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Community.Domain.Model.Common.Interfaces;
using Community.Domain.Model.Userers.Param;
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
        public static Users Get(IUserRepository userRepository,string id)
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
        /// 用户注册信息
        /// </summary>
        /// <returns></returns>
        public static bool Set(IUserRepository userRepository,Users users)
        {
            return userRepository.Set(users);
        }
        #endregion









    }
}

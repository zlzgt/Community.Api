using Community.Application.ApiModel;
using Community.Domain;
using Community.Domain.Model.Userers.Param;
using Community.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Application.IServices
{
    public interface IUserService
    {
        string Test();
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginParam"></param>
        /// <returns></returns>
        ReplyModel Login(LoginParam loginParam);

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        ReplyModel Register(RegisterUserInfo userDto,IServiceProvider serviceProvider);

        /// <summary>
        /// 注册人排序
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        ReplyModel UserSort(PageModel msg);

    }
}

using Community.Application.ApiModel;
using Community.Domain;
using Community.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Application.IServices
{
    public interface IUserService
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        ReplyModel GetLoginInfo(UserInfoModel login);
        /// <summary>
        /// 用户注册信息
        /// </summary>
        /// <returns></returns>
        ReplyModel RegisterInfo(RegisterUserDto userDto);
    }
}

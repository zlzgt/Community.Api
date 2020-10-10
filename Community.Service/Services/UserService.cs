using Community.Application.ApiModel;
using Community.Application.IServices;
using Community.Domain;
using Community.Infrastructure;
using Community.Infrastructure.JwtBreare;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Community.Application.Services
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService 
    {

       #region 错误的逻辑
       // private readonly CommunityDbContext _CommunityDbContext;
       // /// <summary>
       // /// 构造函数注入
       // /// </summary>
       // public UserService(CommunityDbContext dbContext)
       // {
       //     this._CommunityDbContext = dbContext;
       // }
       //
       // /// <summary>
       // /// 用户登录
       // /// </summary>
       // /// <param name="login"></param>
       // /// <returns></returns>
       // public ReplyModel GetLoginInfo(UserInfoModel login)
       // {
       //     ReplyModel reply = new ReplyModel();
       //     try
       //     {
       //         string pwd = MD5Encrypt.Encrypt(login.Password);
       //         string jwtStr = string.Empty;
       //         Users users = _CommunityDbContext.Set<Users>().Where(w => (w.UserName == login.UserName || w.Email == w.UserName) && w.Password == pwd).FirstOrDefault();
       //         if (users != null)
       //         {
       //             TokenModel tokenModel = new TokenModel { Uid = users.Id.ToString(), Role = "admin" };
       //             jwtStr = JwtHelper.issueJwt(tokenModel);
       //             reply.Status = "002";
       //             reply.Msg = "登录成功";
       //             reply.Data = new
       //             {
       //                 jwtStr
       //             };
       //         }
       //         else
       //         {
       //             reply.Msg = "账号或密码错误，请重试";
       //         }
       //     }
       //     catch (Exception ex)
       //     {
       //         reply.Msg = "用户登录出现错误，请重试";
       //         //_Logger.LogError($"用户登录出现异常,{JsonConvert.SerializeObject(ex)}");
       //     }
       //     return reply;
       // }
       //
       //
       // /// <summary>
       // /// 注册用户信息
       // /// </summary>
       // /// <param name="userDto"></param>
       // /// <returns></returns>
       // public ReplyModel RegisterInfo(RegisterUserDto userDto)
       // {
       //     ReplyModel reply = new ReplyModel();
       //     try
       //     {
       //         if (userDto.Password == userDto.RepeatPassword)
       //         {
       //             Users user = _CommunityDbContext.Set<Users>().Where(w => w.UserName == userDto.UserName || w.Email == userDto.Email).FirstOrDefault();
       //             if (user == null)
       //             {
       //                 Users newCUsers = new Users();
       //                 newCUsers.AddTime = DateTime.Now;
       //                 newCUsers.Email = userDto.Email;
       //                 newCUsers.NickName = userDto.NickName;
       //                 newCUsers.Password = MD5Encrypt.Encrypt(userDto.Password);
       //                 newCUsers.Tel = userDto.Tel;
       //                 newCUsers.UserName = userDto.UserName;
       //                 _CommunityDbContext.Set<Users>().Add(newCUsers);
       //                 int iResult = _CommunityDbContext.SaveChanges();
       //                 if (iResult > 0)
       //                 {
       //                     reply.Status = "002";
       //                     reply.Msg = "注册成功";
       //                 }
       //                 else
       //                 {
       //                     reply.Msg = "注册失败";
       //                 }
       //             }
       //             else
       //             {
       //                 reply.Msg = "用户名或邮箱已存在";
       //             }
       //         }
       //         else
       //         {
       //             reply.Msg = "确认密码与输入密码不一致";
       //         }
       //     }
       //     catch (Exception ex)
       //     {
       //         reply.Msg = "用户注册出现异常，请重试";
       //         //_Logger.LogError($"用户注册出现异常{JsonConvert.SerializeObject(ex)}");
       //     }
       //     return reply;
       // }
        #endregion


    }
}

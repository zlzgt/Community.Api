using Community.Application.ApiModel;
using Community.Application.IServices;
using Community.Domain;
using Community.Domain.Model.Common.Interfaces;
using Community.Domain.Model.Userers.Param;
using Community.Infrastructure;
using Community.Infrastructure.JwtBreare;
using EInfrastructure.Core.Config.EntitiesExtensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Community.Reposity.MySql;

namespace Community.Application.Services
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService : IUserService
    {
        #region 属性
        private readonly IUserRepository _userRepository;

        //使用日志组件
        private readonly ILogger<UserService> _logger;



     

        #endregion
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userRepository"></param>
        public UserService(IUserRepository userRepository,ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }


        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginParam"></param>
        /// <returns></returns>
        public ReplyModel Login(LoginParam loginParam)
        {
            _logger.LogInformation("登录日志信息记录");
            ReplyModel reply = new ReplyModel();
            loginParam.Password = MD5Encrypt.Encrypt(loginParam.Password);
            Users user =Users.Get(_userRepository,loginParam);
            if (user == null)
            {
                reply.Msg = "未找到用户信息";
            }
            else
            {
                reply.Status = "002";
                reply.Msg = "登录成功";
            }
            return reply;
        }
        #endregion


        #region 用户注册
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public ReplyModel Register(RegisterUserInfo userDto, IServiceProvider serviceProvider)
        {
            ReplyModel reply = new ReplyModel();
            if (userDto.Password == userDto.RepeatPassword)
            {
                Expression<Func<Users, bool>> func = w => w.UserName == userDto.UserName;
                Users user =Users.Get(_userRepository, func);
                if (user == null)
                {
                    Users.Register(_userRepository, userDto.UserName,userDto.Email,userDto.Password,userDto.NickName,userDto.Tel);
                    bool result = serviceProvider.GetService<IUnitOfWork>().Commit();
                    if (result)
                    {
                        reply.Status = "002";
                        reply.Msg = "注册成功";
                    }
                    else
                    {
                        reply.Msg = "注册失败";
                    }
                }
                else
                {
                    reply.Msg = "用户名或邮箱已存在";
                }
            }
            else
            {
                reply.Msg = "确认密码与输入密码不一致";
            }
            return reply;
        }
        #endregion

        #region 注册人排序
        /// <summary>
        /// 注册人排序
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public ReplyModel UserSort(PageModel msg)
        {
            ReplyModel reply = new ReplyModel();
            try
            {
                string mySql = $@"  select UserId,NickName
                                   from(select UserId, NickName, COUNT(UserId) As ArticleCount
                                        from community_article
                                        where IsDraft=1
                                        group by UserId, NickName
                                        ORDER BY COUNT(UserID) DESC) as UserArticle
                                    LIMIT {(msg.PageIndex - 1) * msg.PageSize}, {msg.PageSize}";

                List<RUserSortModel> userSorts = _userRepository.SqlQuery<RUserSortModel>(mySql).ToList();
                if (userSorts.Any())
                {
                    reply.Status = "002";
                    reply.Msg = "获取数据成功";
                    reply.Data = userSorts;
                }
                else
                {
                    reply.Msg = "没有数据了";
                }
            }
            catch (Exception ex)
            {
                reply.Msg = "注册人排序出现异常，请重试";
            }
            return reply;
        }
        #endregion
       
    }
}

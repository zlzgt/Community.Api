using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Community.Api.AppData;
using Community.Application.ApiModel;
using Community.Application.IServices;
using Community.Domain;
using Community.Domain.Model.Common.Interfaces;
using Community.Domain.Model.Userers.Param;
using Community.Infrastructure;
using EInfrastructure.Core.Config.EntitiesExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Community.Api.Controllers
{
    /// <summary>
    /// 用户账号管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        #region 属性
        private readonly IUserRepository _userRepository;
        protected IServiceProvider ServiceProvider => Request.HttpContext.RequestServices;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userRepository"></param>
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region 用户登录
        /// <summary>
        /// 用户登录测试
        /// </summary>
        /// <returns></returns>
        [HttpPost("Login")]
        [AllowAnonymous]
        public ActionResult<ReplyModel> Login([FromBody] LoginParam msg)
        {
            ReplyModel reply = new ReplyModel();
            msg.Password = MD5Encrypt.Encrypt(msg.Password);
            Users user = _userRepository.Get(msg);
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
        /// <returns></returns>
        [HttpPost("Register")]
        [AllowAnonymous]
        public ActionResult<ReplyModel> Register([FromBody] RegisterUserDto userDto)
        {
            ReplyModel reply = new ReplyModel();
            if (userDto.Password == userDto.RepeatPassword)
            {
                Expression<Func<Users, bool>> func = w => w.UserName == userDto.UserName;
                Users user = _userRepository.Get(func);
                if (user == null)
                {
                    Users newCUsers = new Users();
                    newCUsers.AddTime = DateTime.Now;
                    newCUsers.Email = userDto.Email;
                    newCUsers.NickName = userDto.NickName;
                    newCUsers.Password = MD5Encrypt.Encrypt(userDto.Password);
                    newCUsers.Tel = userDto.Tel;
                    newCUsers.UserName = userDto.UserName;
                    _userRepository.Set(newCUsers);
                    bool result = ServiceProvider.GetService<IUnitOfWork>().Commit();
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

        #region 注册人排行
        /// <summary>
        /// 获取注册人排行
        /// </summary>
        /// <returns></returns>
        [HttpPost("UserSort")]
        public ActionResult<ReplyModel> UserSort([FromBody]PageModel msg)
        {
            ReplyModel reply = new ReplyModel();
            try
            {
                //int skip = (msg.PageIndex - 1) * msg.PageSize + 1;
                //int end = msg.PageIndex * msg.PageSize;
                //SqlParameter[] parameters = new[]{
                //           new SqlParameter("@skip",SqlDbType.Int, skip),
                //           new SqlParameter("@end",SqlDbType.Int,end)
                //         };
                //string sql = $@"select UserId,NickName,RowId
                //                   from(select UserId, NickName, COUNT(UserId) As ArticleCount, ROW_NUMBER() OVER(ORDER BY Count(UserId) desc) as RowId
                //                        from community_article
                //                        where IsDraft ='1'
                //                        group by UserId, NickName) as UserArticle
                //                   where RowId between {skip} and {end}";
                string mySql = $@"  select UserId,NickName
                                   from(select UserId, NickName, COUNT(UserId) As ArticleCount
                                        from community_article
                                        where IsDraft=1
                                        group by UserId, NickName
                                        ORDER BY COUNT(UserID) DESC) as UserArticle
                                    LIMIT {(msg.PageIndex-1)*msg.PageSize}, {msg.PageSize}";


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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Community.Api.AppData;
using Community.Application.ApiModel;
using Community.Application.IServices;
using Community.Domain;
using Community.Domain.Model.Common.Interfaces;
using Community.Domain.Model.Userers.Param;
using Community.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            if(user==null)
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
        public ActionResult<ReplyModel> Register([FromBody] RegisterUserDto msg)
        {

            return new ReplyModel();
          
        }
        #endregion




    }
}

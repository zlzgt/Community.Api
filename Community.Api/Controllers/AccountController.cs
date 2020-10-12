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
using Microsoft.Extensions.Logging;

namespace Community.Api.Controllers
{
    /// <summary>
    /// 用户账号管理
    /// </summary>
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region 属性
        private readonly IUserRepository _userRepository;
        protected IServiceProvider ServiceProvider => Request.HttpContext.RequestServices;

        private readonly IUserService _userService;

       /// <summary>
       /// 使用日志组件
       /// </summary>
        private readonly ILogger<AccountController>  _logger;

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="userService"></param>
        public AccountController(IUserRepository userRepository, IUserService userService,ILogger<AccountController> logger)
        {
            _userRepository = userRepository;
            _userService = userService;
            _logger = logger;
        }
        #endregion

        #region 用户登录
        /// <summary>
        /// 用户登录测试
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ActionName("login")]
        public ActionResult<ReplyModel> Login([FromBody] LoginParam msg)
        {
            return _userService.Login(msg);
        }
        #endregion

        #region 用户注册
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ActionName("register")]
        public ActionResult<ReplyModel> Register([FromBody] RegisterUserDto userDto)
        {
            return _userService.Register(userDto, ServiceProvider);
        }
        #endregion

        #region 注册人排行
        /// <summary>
        /// 获取注册人排行
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("usersort")]
        public ActionResult<ReplyModel> UserSort([FromBody]PageModel msg)
        {
            return _userService.UserSort(msg);
        }
        #endregion


        #region 测试依赖注入
        /// <summary>
        /// 依赖注入测试
        /// </summary>
        [HttpGet("Test")]
        public ActionResult<string> Test()
        {
            _logger.LogInformation("log4net日志的使用");
            return _userService.Test();
        }
        #endregion 

    }
}

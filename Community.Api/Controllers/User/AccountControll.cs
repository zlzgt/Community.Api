using Community.Application.ApiModel;
using Community.Application.IServices;
using Community.Domain.Model.Common.Interfaces;
using Community.Domain.Model.Userers.Param;
using Community.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Community.Api.Controllers.User
{
    /// <summary>
    /// 用户账号管理
    /// </summary>
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class AccountController : Controller
    {
        #region 属性
        private readonly IUserRepository _userRepository;
        protected IServiceProvider ServiceProvider => Request.HttpContext.RequestServices;

        private readonly IUserService _userService;

        /// <summary>
        /// 使用日志组件
        /// </summary>
        private readonly ILogger<AccountController> _logger;

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="userService"></param>
        public AccountController(IUserRepository userRepository, IUserService userService, ILogger<AccountController> logger)
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
        public JsonResult Login([FromBody] LoginParam msg)
        {
            return Json(_userService.Login(msg));
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
        public JsonResult Register([FromBody] RegisterUserInfo userDto)
        {
            return Json(_userService.Register(userDto, ServiceProvider));
        }
        #endregion

        #region 注册人排行
        /// <summary>
        /// 获取注册人排行
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("usersort")]
        public JsonResult UserSort([FromBody]PageModel msg)
        {
            return Json(_userService.UserSort(msg));
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

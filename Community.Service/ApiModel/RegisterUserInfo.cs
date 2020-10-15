using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Community.Application.ApiModel
{
    /// <summary>
    /// 用户注册信息
    /// </summary>
    public class RegisterUserInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }
        /// <summary>
        /// 用户Email
        /// </summary>
        [Required(ErrorMessage = "邮箱不能为空")]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "邮箱格式不正确")]
        public string Email { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
        /// <summary>
        /// 重复密码
        /// </summary>
        [Required(ErrorMessage = "重复密码不能为空")]
        public string RepeatPassword { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [Required(ErrorMessage = "昵称不能为空")]
        public string NickName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [Required(ErrorMessage = "手机号不能为空")]
        [RegularExpression("^(1)\\d{10}$", ErrorMessage = "手机号格式正确")]
        public string Tel { get; set; }
    }
}

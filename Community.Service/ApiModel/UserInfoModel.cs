using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Community.Application.ApiModel
{
    /// <summary>
    /// 用户登录
    /// </summary>
    public class UserInfoModel
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(32, ErrorMessage = "用户名长度不能超过32个字符")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
    }
}

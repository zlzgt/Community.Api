using Community.Domain.Model.Userers.Entity;
using EInfrastructure.Core.Config.EntitiesExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Transactions;

namespace Community.Domain
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public partial class Users : AggregateRoot<string>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; private set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; private set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName { get; private set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        public string Tel { get; private set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; private set; }
       
       
        public Users()
        {
            Id = Guid.NewGuid().ToString();
        }






    }
}

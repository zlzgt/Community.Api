using EInfrastructure.Core.Config.EntitiesExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Community.Domain
{
   /// <summary>
   /// 用户信息
   /// </summary>
    public partial class Users : AggregateRoot<string>
    {

        /// <summary>
        ///主键
        /// </summary>
        public Users()
        {
            Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(32), Required]
        public string UserName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(32), Required]
        public string Email { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(64), Required]
        public string Password { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        [MaxLength(64)]
        public string NickName { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        [MaxLength(11), Required]
        public string Tel { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 用户评论
        /// </summary>
        public virtual ICollection<Comment> Comments { get; set;} = new List<Comment>();
        /// <summary>
        ///  用户文章
        /// </summary>
        public virtual ICollection<Article> Articles { get; set; } = new List<Article>();


    }
}

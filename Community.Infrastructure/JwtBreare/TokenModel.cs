using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Infrastructure.JwtBreare
{
    /// <summary>
    /// 令牌
    /// </summary>
    public class TokenModel
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public string Role { get; set; }
    }
}

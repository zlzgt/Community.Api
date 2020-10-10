using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Community.Infrastructure
{
    /// <summary>
    /// 响应消息类
    /// </summary>
    public class ReplyModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public string Status { get; set; } = "001"; // 002 正确提示
        /// <summary>
        /// 消息提示
        /// </summary>
        public string Msg { get; set; } = "测试消息";
        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }
    }
}

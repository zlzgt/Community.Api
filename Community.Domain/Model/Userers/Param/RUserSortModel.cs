using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Domain.Model.Userers.Param
{
    public class RUserSortModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 用户排名
        /// </summary>
        public Int64 RowId { get; set; }
    }
}

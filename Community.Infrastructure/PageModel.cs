using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Community.Infrastructure
{
    /// <summary>
    /// 分页
    /// </summary>
    public class PageModel
    {
        /// <summary>
        ///  当前页
        /// </summary>
        [Required(ErrorMessage = "页面索引不能为空")]
        public int PageIndex { get; set; } = 1;
        /// <summary>
        ///  页面大小
        /// </summary>
        [Required(ErrorMessage = "页面大小不能为空")]
        public int PageSize { get; set; } = 10;  //页面大小
        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string Keyword { get; set; }  //搜索关键字
        /// <summary>
        /// 关键Id搜索
        /// </summary>
        public int KeyId { get; set; } //根据Id进行搜索
    }
}

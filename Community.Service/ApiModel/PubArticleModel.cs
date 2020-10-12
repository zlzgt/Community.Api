
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Community.Application.ApiModel
{
    /// <summary>
    /// 文章发布或保存草稿
    /// </summary>
    public class PubArticleModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "标题不能为空")]
        public string Title { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        [Required(ErrorMessage = "内容不能为空")]
        public string Content { get; set; }
        /// <summary>
        /// 高级选项， Json字符串
        /// </summary>
        public string AdvancedOptions { get; set; }
        /// <summary>
        /// 友好地址
        /// </summary>
        public string EntryName { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        [Required(ErrorMessage = "摘要不能为空")]
        public string Summary { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        [Required(ErrorMessage = "标签Id不能为空")]
        public string TagId { get; set; }
        /// <summary>
        /// 标签名
        /// </summary>
        public string TagName { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 是否是草稿 0 是 1 不是
        /// </summary>
        public int IsDraft { get; set; }
        /// <summary>
        /// 摘要图片
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 密码保护
        /// </summary>
        public string Password { get; set; }
    }
}

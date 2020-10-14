using Community.Domain.Model.Articles.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Community.Domain.Model.Articles.Param
{
    public class ArticleParam
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [Required(ErrorMessage ="用户Id不能为空")]
        public string UserId { get;  set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string NickName { get;  set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage ="标题不能为空")]
        public string Title { get;  set; }
        /// <summary>
        /// 是否为草稿
        /// </summary>
        public int IsDraft { get;  set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required(ErrorMessage ="文章内容不能为空")]
        public string Content { get;  set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string Summary { get;  set; }
        /// <summary>
        /// 摘要图片
        /// </summary>
        public string Img { get;  set; }
        /// <summary>
        /// 高级选项配置
        /// </summary>
        public string Config { get;  set; }
        /// <summary>
        /// 友好地址
        /// </summary>
        public string EntryName { get; set; }
        /// <summary>
        ///  文章标签
        /// </summary>
        public List<ArticleCategory> ArticleCategory { get; set; }
        /// <summary>
        /// 保护密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PubTime { get; set; }
  
    }
}

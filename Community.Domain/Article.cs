
using Community.Domain.Model.Articles.Entity;
using EInfrastructure.Core.Config.EntitiesExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Community.Domain
{
    /// <summary>
    /// 文章
    /// </summary>
    public partial class Article : AggregateRoot<string>
    {

        public Article()
        {
            Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; private set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string NickName { get;  private  set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// 是否为草稿
        /// </summary>
        public int IsDraft { get; private set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; private set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string Summary { get; private set; }
        /// <summary>
        /// 摘要图片
        /// </summary>
        public string Img { get; private set; }
        /// <summary>
        /// 高级选项配置
        /// </summary>
        public string Config { get; private set; }
        /// <summary>
        /// 友好地址
        /// </summary>
        public string EntryName { get; private set; }
        /// <summary>
        ///  文章标签
        /// </summary>
        public IEnumerable<ArticleCategory> ArticleCategory
        {
            get => JsonConvert.DeserializeObject<List<ArticleCategory>>(ArticleCategoryJson);
            set => ArticleCategoryJson = JsonConvert.SerializeObject(value);
        }
        public string ArticleCategoryJson { get; private set; }
        /// <summary>
        /// 阅读数量
        /// </summary>
        public int ReadCount { get; private set; }
        /// <summary>
        /// 保护密码
        /// </summary>
        public string Password { get; private set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PubTime { get; private set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; private set; }

    }
}

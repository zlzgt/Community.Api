using Abp.Webhooks;
using Community.Domain;
using Community.Infrastructure;
using EInfrastructure.Core.Config.Entities.Data;
using EInfrastructure.Core.Config.Entities.Extensions;
using EInfrastructure.Core.Config.EntitiesExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Community.Application.ApiModel
{
    /// <summary>
    /// 文章列表信息
    /// </summary>
    public class ArticlesDto
    {


        /// <summary>
        /// 文章Id
        /// </summary>
        public string Id { get; set;}

        /// <summary>
        /// 文章发布时间
        /// </summary>
        [JsonProperty(PropertyName = "pubtime")]
        public string PubTime { get; set; }

        /// <summary>
        /// 文章添加时间
        /// </summary>
        [JsonProperty(PropertyName = "addtime")]
        public string AddTime { get; set; }
        /// <summary>
        /// 文章摘要
        /// </summary>
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        /// <summary>
        /// 阅读数量
        /// </summary>
        [JsonProperty(PropertyName = "readcount")]
        public int ReadCount { get; set; }

        #region  获取文章列表信息
        /// <summary>
        /// 获取文章列表信息
        /// </summary>
        /// <param name="articleQuery"></param>
        /// <returns></returns>
        public static PageData<ArticlesDto> GetList(IQuery<Article, string> articleQuery,PageModel page)
        {
            Expression<Func<Article, bool>> func = w => true;
            return articleQuery.GetQueryable().Where(func).Select(w => new ArticlesDto
            {
                PubTime = w.PubTime.ToString("yyyy年MM月dd日"),
                AddTime = w.AddTime.ToString("yyyy-MM-dd HH:mm:ss"),
                Summary=w.Summary,
                UserName=w.NickName,
                ReadCount=w.ReadCount,
                Id=w.Id
            }).ListPager(page.PageSize, page.PageIndex, true);
        }
        #endregion







    }
}

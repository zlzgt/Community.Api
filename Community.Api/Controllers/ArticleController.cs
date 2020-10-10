using Community.Application.ApiModel;
using Community.Application.IServices;
using Community.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Community.Api.Controllers
{
    /// <summary>
    /// 文章管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        /// <summary>
        /// 用户服务
        /// </summary>
        private readonly IArticleService _ArticleService;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        public ArticleController(IArticleService artcleService)
        {
            this._ArticleService = artcleService;
        }

        #region 文章发布或保存草稿
        /// <summary>
        /// 文章发布或保存草稿
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [HttpPost("PubArticle")]
        [Authorize]
        public ActionResult<ReplyModel> PubArticle([FromBody] PubArticleModel msg)
        {
            return _ArticleService.PubArticle(msg);
        }
        #endregion


        #region 获取文章列表
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("Articles")]
        public ActionResult<ReplyModel> Articles([FromBody] PageModel msg)
        {
            return _ArticleService.Articles(msg);
        }
        #endregion

    }
}

using Community.Application.ApiModel;
using Community.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Application.IServices
{
    public interface IArticleService
    {
        /// <summary>
        /// 文章发布或保存草稿
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        ReplyModel PubArticle(PubArticleModel msg);

        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        ReplyModel Articles(PageModel msg);




    }
}

using Community.Domain;
using Community.Infrastructure;
using EInfrastructure.Core.Config.Entities.Data;
using EInfrastructure.Core.Config.Entities.Extensions;
using EInfrastructure.Core.Config.EntitiesExtensions;
using EInfrastructure.Core.Configuration.Ioc.Plugs.Storage.Params.Bucket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Community.Api.Models.Categories
{
    /// <summary>
    /// 分类数据传输对象
    /// </summary>
    public class CategoryDto
    {
        /// <summary>
        /// 分类Id
        /// </summary>
        public string Id { get; set;}

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; private set; }



        #region 获取分类信息
        /// <summary>
        /// 获取分类信息
        /// </summary>
        public static CategoryDto  GetCategoryInfo(IQuery<Category, string> categoryQuery, string title)
        {
            Expression<Func<Category, bool>> func = w => w.Title == title;
            return categoryQuery.GetQueryable().Where(func).Select(w => new CategoryDto {
                AddTime = w.AddTime,
                Description=w.Description,
                Title=w.Title,
                Id=w.Id
            }).FirstOrDefault();
         
        }
        #endregion


        #region  获取分类列表
        /// <summary>
        /// 获取文章列表信息
        /// </summary>
        /// <param name="articleQuery"></param>
        /// <returns></returns>
        public static PageData<CategoryDto> GetList(IQuery<Category, string> categoryQuery, PageModel page)
        {
            Expression<Func<Category, bool>> func = w => true;
            return categoryQuery.GetQueryable().Where(func).Select(w => new CategoryDto
            {
                Id = w.Id,
                Title = w.Title,
                Description = w.Description,
                AddTime=w.AddTime
            }).ListPager(page.PageSize, page.PageIndex, true);
        }
        #endregion




    }
}

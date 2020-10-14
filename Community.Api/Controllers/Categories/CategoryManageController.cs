using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Community.Api.Models.Categories;
using Community.Domain;
using Community.Domain.Model.Categorys.Param;
using Community.Domain.Model.Common.Interfaces;
using Community.Infrastructure;
using EInfrastructure.Core.Config.Entities.Data;
using EInfrastructure.Core.Config.EntitiesExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
namespace Community.Api.Controllers.Categories
{
    /// <summary>
    /// 分类管理
    /// </summary>
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CategoryManageController :Controller
    {

        #region 属性
        private readonly ICategoryRepository _categoryRepository;
        protected IServiceProvider ServiceProvider => Request.HttpContext.RequestServices;

        public readonly IQuery<Category, string> _categoryQuery;

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public CategoryManageController(ICategoryRepository categoryRepository,IQuery<Category,string> category)
        {
            _categoryRepository = categoryRepository;
            _categoryQuery = category;
        }

        #region 添加分类
        /// <summary>
        /// 添加分类测试
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("add")]
        public ActionResult<ReplyModel> Add([FromBody]CategoryParam msg)
        {
            ReplyModel replyModel = new ReplyModel();
            Expression<Func<Category, bool>> func = w => w.Title == msg.Title;
            CategoryDto category =CategoryDto.GetCategoryInfo(_categoryQuery, msg.Title);
            if (category == null)
            {
                Category.Add(_categoryRepository,msg.Title,msg.Description);
                bool result = ServiceProvider.GetService<IUnitOfWork>().Commit();
                if (result)
                {
                    replyModel.Status = "002";
                    replyModel.Msg = "添加标题成功";
                }
                else
                {
                    replyModel.Msg = "添加标题失败";
                }
            }
            else
            {
                replyModel.Msg = "该分类已经存在";
            }
            return replyModel;
        }
        #endregion

        #region 获取标题列表
        /// <summary>
        /// 获取标题列表
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("categories")]
        public ActionResult<ReplyModel> Categories([FromBody]PageModel msg)
        {
            ReplyModel reply = new ReplyModel();
            PageData<CategoryDto> categories= CategoryDto.GetList(_categoryQuery, msg);
            if(categories.Data.Any())
            {
                reply.Status = "002";
                reply.Msg = "获取数成功";
                reply.Data = categories;
            }
            else
            {
                reply.Msg = "没有数据了";
            }
            return reply;
        }
        #endregion


    }
}
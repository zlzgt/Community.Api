using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Community.Domain.Model.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Community.Domain
{
    public partial class Category
    {
        #region 获取分类信息
        /// <summary>
        /// 获取分类信息
        /// </summary>
        /// <param name="categoryRepository"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public Category Get(ICategoryRepository categoryRepository, Expression<Func<Category,bool>> func)
        {
            return categoryRepository.Get(func);
        }
        #endregion

        #region 设置分类信息
        /// <summary>
        /// 设置分析信息
        /// </summary>
        /// <param name="categoryRepository"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public bool Set(ICategoryRepository categoryRepository ,Category category)
        {
            return categoryRepository.Set(category);
        }

        #endregion





    }
}

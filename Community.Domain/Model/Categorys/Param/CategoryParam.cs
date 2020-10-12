using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Community.Domain.Model.Categorys.Param
{
    /// <summary>
    /// 分类参数
    /// </summary>
    public class CategoryParam
    {
        /// <summary>
        /// 分类
        /// </summary>
        [Required(ErrorMessage ="分类标题不能为空")]
        public string Title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}

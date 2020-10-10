using Community.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Community.Api.Attribute
{

    /// <summary>
    /// Api action统一处理过滤器
    /// </summary>
    public class ApiResponseFilterAttribute: ActionFilterAttribute
    {
        /// <summary>
        /// 对Action的参数进行校验
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //模型验证
            if (!context.ModelState.IsValid)
            {
                //throw new ApplicationException(context.ModelState.Values.First(p => p.Errors.Count > 0).Errors[0].ErrorMessage);
                ReplyModel reply = new ReplyModel();
                reply.Msg = context.ModelState.Values.First(p => p.Errors.Count > 0).Errors[0].ErrorMessage;
                context.Result = new JsonResult(reply);
            }
            base.OnActionExecuting(context);
        }

        /// <summary>
        /// 处理正常返回的结果对象，进行统一json格式包装
        /// 异常只能交由ExceptionFilterAttribute 去处理 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result != null)
            {
                var result = context.Result as ObjectResult;
                JsonResult newresult;
                if (context.Result is ObjectResult)
                {
                    newresult = new JsonResult(result.Value);
                    //  newresult = new JsonResult(new { code = 200, data = result.Value });
                }
                else if (context.Result is EmptyResult)
                {
                    newresult = new JsonResult(new { });
                    //newresult = new JsonResult(new { code = 200, data = new { } });
                }
                else
                {
                    throw new Exception($"未经处理的Result类型：{ context.Result.GetType().Name}");
                }
                context.Result = newresult;
            }
            base.OnActionExecuted(context);
        }
    }
}

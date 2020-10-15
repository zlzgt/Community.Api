using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Domain.Model.Userers.Event
{
    public class UserArticleEvent
    {
        /// <summary>
        /// 修改用户文章数量
        /// </summary>
        public static List<Action<IServiceProvider,Users>> AlterUserAritlceCountEvent = new List<Action<IServiceProvider,Users>>();

    }

    public static class UserArticleEventExtend
    {
        /// <summary>
        /// 触发修改用户发表文章数量
        /// </summary>
        /// <param name="user"></param>
        /// <param name="serviceProvider"></param>
        /// <param name="userId"></param>
        public static void TriggerAlterUserAritlceCountEvent(this Users user, IServiceProvider serviceProvider)
        {
            UserArticleEvent.AlterUserAritlceCountEvent?.ForEach(action => action(serviceProvider,user));

        }
    }

}

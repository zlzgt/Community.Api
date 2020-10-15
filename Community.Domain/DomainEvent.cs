using System;
using System.Collections.Generic;
using System.Text;

namespace Community.Domain
{
    /// <summary>
    /// 注册领域事件
    /// </summary>
    public class DomainEvent
    {

        private static bool IsRegister = false;
        private static object lockObj = new object();

        public static void Register()
        {
            if (IsRegister)
            {
                return;
            }

            lock (lockObj)
            {
                if (!IsRegister)
                {
                    Users.RegisterEvent();
                }
            }
        }



    }
}

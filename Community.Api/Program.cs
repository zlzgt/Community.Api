using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Community.Api
{
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        /// <summary>
        ///  创建主机
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .ConfigureLogging((context, loggingBuilder) =>
               {
                   loggingBuilder.AddFilter("System", LogLevel.Warning);
                   loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
                   var path = context.HostingEnvironment.ContentRootPath;
                   loggingBuilder.AddLog4Net($"{path}/log4net.config");//配置文件
               })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
               .UseServiceProviderFactory(new AutofacServiceProviderFactory());
    }
}

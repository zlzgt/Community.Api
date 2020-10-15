using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Community.Domain;
using Community.Infrastructure;
using Autofac;
using Community.Api.AppData;
using Community.Reposity.MySql;

namespace Community.Api
{
    /// <summary>
    /// WebApi������
    /// </summary>
    public class Startup
    {

        /// <summary>
        /// ע���������
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            //���������д���ݿ�������ַ���
            var connection = ConfigurationManagerHelper.conn;
            services.AddDbContext<CommunityDbContext>(options => options.UseMySql(connection,
             p => p.MigrationsAssembly("Community.Domain")));

            // ʹ��Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "Community WebaPI", Version = "1.0" });
                string str = typeof(Startup).Assembly.GetName().Name;
                // include document file
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(Startup).Assembly.GetName().Name}.xml"), true);
            });

            //ע�������¼�
            DomainEvent.Register();


        }

        /// <summary>
        ///  ʹ��Autofac����ע��
        /// </summary>
        /// <param name="containerBuilder"></param>
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<ConfigureAutofac>();
        }




        /// <summary>
        ///  ����HTTP����ܵ�
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "My Demo API (V 1.0)");
            });

            app.UseRouting();

            //�������
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}

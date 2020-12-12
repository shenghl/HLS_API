using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace StarsAPI
{
    public class Startup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            #region Swagger
            services.AddSwaggerGen(c=> 
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1.0.0",
                    Title = "Stars API",
                    Description = "框架说明文档",
                    TermsOfService = new Uri("https://blog.csdn.net/Tiger_shl"),
                    Contact = new OpenApiContact {
                        Name = "StarsAPI",
                        Email = "15077914772@163.com",
                        Url = new Uri("https://blog.csdn.net/Tiger_shl"),
                    },
                });
                //接口配置注释
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "StarsAPI.xml");
                c.IncludeXmlComments(xmlPath,true);
                //实体类配置注释
                var xmlModelPath = Path.Combine(basePath, "StarsAPI.Model.xml");
                c.IncludeXmlComments(xmlModelPath);

                //添加header验证信息
                //net core 3.1的写法
                //开启加权小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //在header中添加token传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                //必须是oauth2
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme 
                { 
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

            });
            #endregion
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c=>
            {
                var ApiName = "Stars API";
                var version = "v1";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{ApiName}{version}");
                // 将swagger首页，设置成我们自定义的页面，记得这个字符串的写法：解决方案名.index.html
                //这里是配合MiniProfiler进行性能监控的，《文章：完美基于AOP的接口性能分析》，如果你不需要，可以暂时先注释掉，不影响大局。
                //c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("Blog.Core.index.html");
                c.RoutePrefix = "";//路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，
            });

            //app.UseMvc();


        }
    }
}

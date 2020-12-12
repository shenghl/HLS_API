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
        /// ���캯��
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
                    Description = "���˵���ĵ�",
                    TermsOfService = new Uri("https://blog.csdn.net/Tiger_shl"),
                    Contact = new OpenApiContact {
                        Name = "StarsAPI",
                        Email = "15077914772@163.com",
                        Url = new Uri("https://blog.csdn.net/Tiger_shl"),
                    },
                });
                //�ӿ�����ע��
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "StarsAPI.xml");
                c.IncludeXmlComments(xmlPath,true);
                //ʵ��������ע��
                var xmlModelPath = Path.Combine(basePath, "StarsAPI.Model.xml");
                c.IncludeXmlComments(xmlModelPath);

                //���header��֤��Ϣ
                //net core 3.1��д��
                //������ȨС��
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //��header�����token���ݵ���̨
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                //������oauth2
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme 
                { 
                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�",
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
                // ��swagger��ҳ�����ó������Զ����ҳ�棬�ǵ�����ַ�����д�������������.index.html
                //���������MiniProfiler�������ܼ�صģ������£���������AOP�Ľӿ����ܷ�����������㲻��Ҫ��������ʱ��ע�͵�����Ӱ���֡�
                //c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("Blog.Core.index.html");
                c.RoutePrefix = "";//·�����ã�����Ϊ�գ���ʾֱ���ڸ�������localhost:8001�����ʸ��ļ�,ע��localhost:8001/swagger�Ƿ��ʲ����ģ�
            });

            //app.UseMvc();


        }
    }
}

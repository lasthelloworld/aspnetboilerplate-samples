using System.Reflection;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace SimpleTaskSystem.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(SimpleTaskSystemApplicationModule))]
    public class SimpleTaskSystemWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //Application Service的public方法发布成Web Api接口，可以供客户端通过ajax调用。
            //SimpleTaskSystemApplicationModule这个程序集中所有继承了IApplicationService接口的类，
            //都会自动创建相应的ApiController，其中的公开方法，就会转换成WebApi接口方法。
            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(SimpleTaskSystemApplicationModule).Assembly, "app")
                .Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
        }
    }
}

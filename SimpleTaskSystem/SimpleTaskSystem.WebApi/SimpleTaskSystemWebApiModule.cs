using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace SimpleTaskSystem
{
    /// <summary>
    /// 'Web API layer module' for this project.
    /// </summary>
    [DependsOn(typeof(AbpWebApiModule), typeof(SimpleTaskSystemApplicationModule))]
    public class SimpleTaskSystemWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            //This code is used to register classes to dependency injection system for this assembly using conventions.
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //Creating dynamic Web Api Controllers for application services.
            //Thus, 'web api layer' is created automatically by ABP.

            //Application Service的public方法发布成Web Api接口，可以供客户端通过ajax调用。
            //SimpleTaskSystemApplicationModule这个程序集中所有继承了IApplicationService接口的类，
            //都会自动创建相应的ApiController，其中的公开方法，就会转换成WebApi接口方法。
            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(Assembly.GetAssembly(typeof (SimpleTaskSystemApplicationModule)), "tasksystem")
                .Build();
        }
    }
}

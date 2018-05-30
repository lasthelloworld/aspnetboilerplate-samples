using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using SimpleTaskSystem.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace SimpleTaskSystem.Migrations
{
    // 通过数据迁移配置文件 Code first 生成数据库文件
    /**
    *在VS2013底部的“程序包管理器控制台”窗口中，选择默认项目并执行命令“Add-Migration InitialCreate” 
    * 会在Migrations文件夹下生成一个xxxx-InitialCreate.cs文件
    * 
    * 
    * 在“程序包管理器控制台”执行“Update-Database”，会自动在数据库创建相应的数据表
    * 
    * 更新重复上面的操作
    * **/
    public sealed class Configuration : DbMigrationsConfiguration<SimpleTaskSystem.EntityFramework.SimpleTaskSystemDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SimpleTaskSystem";
        }

        protected override void Seed(SimpleTaskSystem.EntityFramework.SimpleTaskSystemDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}

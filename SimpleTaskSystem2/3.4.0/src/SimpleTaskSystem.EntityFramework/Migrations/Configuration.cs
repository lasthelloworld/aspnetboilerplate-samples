using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using SimpleTaskSystem.Migrations.SeedData;
using EntityFramework.DynamicFilters;
using SimpleTaskSystem.Entities;

namespace SimpleTaskSystem.Migrations
{
    // ͨ������Ǩ�������ļ� Code first �������ݿ��ļ�
    /**
    *��VS2013�ײ��ġ����������������̨�������У�ѡ��Ĭ����Ŀ��ִ�����Add-Migration InitialCreate�� 
    * ����Migrations�ļ���������һ��xxxx-InitialCreate.cs�ļ�
    * 
    * 
    * �ڡ����������������̨��ִ�С�Update-Database�������Զ������ݿⴴ����Ӧ�����ݱ�
    * 
    * �����ظ�����Ĳ���
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

            //���ݴ�����ʵ���ϵ��ʹ��Code First��ʽ�������ݱ�
            context.People.AddOrUpdate(
                   p => p.Name,
                   new Person { Name = "A" },
                   new Person { Name = "B"}
                );

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

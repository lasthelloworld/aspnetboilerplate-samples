using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using SimpleTaskSystem.Authorization.Roles;
using SimpleTaskSystem.Authorization.Users;
using SimpleTaskSystem.Entities;//引入实体类库
using SimpleTaskSystem.MultiTenancy;

namespace SimpleTaskSystem.EntityFramework
{
    //数据库操作实体框架工作单元和存储库模式的组合，创建实体操作接口IDbSet
    public class SimpleTaskSystemDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual IDbSet<Task> Tasks { get; set; }
        public virtual IDbSet<Person> People { get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public SimpleTaskSystemDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in SimpleTaskSystemDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of SimpleTaskSystemDbContext since ABP automatically handles it.
         */
        public SimpleTaskSystemDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public SimpleTaskSystemDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public SimpleTaskSystemDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}

using System.Data.Common;
using System.Data.Entity;
using Abp.EntityFramework;
using SimpleTaskSystem.People;
using SimpleTaskSystem.Tasks;

namespace SimpleTaskSystem.EntityFramework
{
    //数据库操作实体框架工作单元和存储库模式的组合，创建实体操作接口IDbSet
    public class SimpleTaskSystemDbContext : AbpDbContext
    {
        public virtual IDbSet<Task> Tasks { get; set; }

        public virtual IDbSet<Person> People { get; set; }

        public SimpleTaskSystemDbContext()
            : base("Default")
        {

        }

        public SimpleTaskSystemDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            
        }

        //This constructor is used in tests
        public SimpleTaskSystemDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}

using System.Collections.Generic;
using Abp.Domain.Repositories;

namespace SimpleTaskSystem.Tasks
{
    /// <summary>
    /// Defines a repository to perform database operations for <see cref="Task"/> Entities.
    /// 定义仓储接口：让仓储类继承
    /// 通过仓储模式，可以更好把业务代码与数据库操作代码更好的分离，可以针对不同的数据库有不同的实现类，而业务代码不需要修改。
    /// 
    /// Extends <see cref="IRepository{TEntity, TPrimaryKey}"/> to inherit base repository functionality. 
    /// IRepository:具有基本的CRUD
    /// ITaskRepository:扩展特殊方法
    /// </summary>
    public interface ITaskRepository : IRepository<Task, long>
    {
        /// <summary>
        /// Gets all tasks with <see cref="Task.AssignedPerson"/> is retrived (Include for EntityFramework, Fetch for NHibernate)
        /// filtered by given conditions.
        /// </summary>
        /// <param name="assignedPersonId">Optional assigned person filter. If it's null, not filtered.</param>
        /// <param name="state">Optional state filter. If it's null, not filtered.</param>
        /// <returns>List of found tasks</returns>
        List<Task> GetAllWithPeople(int? assignedPersonId, TaskState? state);

        /// <summary>
        /// 根据选中的ID集合删除多个任务
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        void DeleteTasks(List<long> ids);
    }
}

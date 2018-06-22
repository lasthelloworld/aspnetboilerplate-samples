using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SimpleTaskSystem.People
{
    /// <summary>
    /// Represents a Person entity.
    ///  继承基类 Entity  包含一个ID属性，不同ID类型可以继承不同类 Task类继承自Entity<long>
    /// It inherits from <see cref="Entity"/> class (Optionally can implement <see cref="IEntity"/> directly).
    /// </summary>
    [Table("StsPeople")]
    public class Person : Entity
    {
        /// <summary>
        /// A property (database field) for a Person to store his/her name.
        /// NOTE: NHibernate requires that all members of an entity must be virtual (for proxying purposes)!
        /// </summary>
        public virtual string Name { get; set; }
    }
}
using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleTaskSystem.Entities
{
    public class Task: Entity<long>
    {
        [ForeignKey("AssignedPersonId")]
        public virtual Person AssignedPerson { get; set; } //导航属性用于引用Person
        public virtual int? AssignedPersonId { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual TaskState? State { get; set; }


    }
}
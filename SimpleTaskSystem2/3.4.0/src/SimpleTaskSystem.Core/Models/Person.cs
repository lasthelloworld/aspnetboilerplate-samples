using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleTaskSystem.Models
{
    public class Person : Entity
    {
       public virtual string Name { get; set; }
    }
}
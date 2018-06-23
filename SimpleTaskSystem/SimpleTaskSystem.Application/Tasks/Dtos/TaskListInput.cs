using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;//自定义验证

namespace SimpleTaskSystem.Tasks.Dtos
{
    /// <summary>
    /// 任务列表实体
    /// </summary>
    public class TaskListInput : ICustomValidate
    {
        public List<TaskDto> Tasks { get; set; }
        public void AddValidationErrors(CustomValidationContext context)
        {
            if(Tasks==null || Tasks.Count == 0)
            {
                context.Results.Add(new ValidationResult("请至少选择一条任务", new[] { "TaskId", "AssignedPersonId" }));
            }
            
        }
    }
}
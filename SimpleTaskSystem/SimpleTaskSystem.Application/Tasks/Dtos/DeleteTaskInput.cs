using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;//自定义验证

namespace SimpleTaskSystem.Tasks.Dtos
{
    /// <summary>
    /// 删除输入实体
    /// </summary>
    public class DeleteTaskInput : ICustomValidate
    {
        public long TaskId { get; set; }

        public int? AssignedPersonId { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (AssignedPersonId == null && TaskId ==0)
            {
                context.Results.Add(new ValidationResult("任务ID和员工ID不能同时为空", new[] { "TaskId", "AssignedPersonId" }));
;            }
        }

        public override string ToString()
        {
            return string.Format("[DeleteTaskInput > TaskId = {0}, AssignedPersonId = {1}]", TaskId, AssignedPersonId);
        }
    }
}

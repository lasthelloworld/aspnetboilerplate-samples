using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SimpleTaskSystem.Roles.Dto;
using SimpleTaskSystem.Users.Dto;

namespace SimpleTaskSystem.Users
{
    //继承IApplicationService，ABP自动为这个类提供一些功能特性依赖注入,数据验证
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}
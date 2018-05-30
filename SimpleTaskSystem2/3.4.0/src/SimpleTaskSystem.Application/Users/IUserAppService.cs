using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SimpleTaskSystem.Roles.Dto;
using SimpleTaskSystem.Users.Dto;

namespace SimpleTaskSystem.Users
{
    //�̳�IApplicationService��ABP�Զ�Ϊ������ṩһЩ������������ע��,������֤
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}
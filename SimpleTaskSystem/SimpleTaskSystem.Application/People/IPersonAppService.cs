using System.Threading.Tasks;
using Abp.Application.Services;
using SimpleTaskSystem.People.Dtos;

namespace SimpleTaskSystem.People
{
    //继承IApplicationService，ABP自动为这个接口提供数据库CRUD，并在该接口上扩展新的接口方法
    public interface IPersonAppService : IApplicationService
    {
        Task<GetAllPeopleOutput> GetAllPeople();
    }
}

using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using CentersFrontier.Production.Tasks.Dto;

namespace CentersFrontier.Production.Tasks
{
    public interface ITaskAppService : IAsyncCrudAppService<TaskDto, long, PagedTaskResultRequestDto, CreateTaskDto, TaskDto>
    {
        Task ReceiveTask(ReceiveTaskInput input);
        Task ActivateTask(long id);
        Task DeactivateTask(long id);
        Task ToggleActivationStatus(long id);
        Task GoProduction(GoProductionInput input);
    }

    public interface IMainTaskAppService : ITaskAppService
    {
    }

    public interface ISideTaskAppService : ITaskAppService
    {
    }
}
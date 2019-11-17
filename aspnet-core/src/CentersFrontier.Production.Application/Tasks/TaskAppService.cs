using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using CentersFrontier.Production.Tasks.Dto;

namespace CentersFrontier.Production.Tasks
{
    public class TaskAppService<TTask> : AsyncCrudAppService<TTask, TaskDto, long, PagedTaskResultRequestDto, CreateTaskDto, TaskDto>, ITaskAppService
    where TTask : ManufacturingTask
    {
        public TaskAppService(IRepository<TTask, long> repository) : base(repository)
        {
        }

        public async Task ActivateTask(long id)
        {
            var task = await Repository.GetAsync(id);
            if (task.IsActive)
                throw new UserFriendlyException("任务已处于激活状态");
            task.IsActive = true;
        }

        public async Task DeactivateTask(long id)
        {
            var task = await Repository.GetAsync(id);
            if (!task.IsActive)
                throw new UserFriendlyException("任务已处于未激活状态");
            task.IsActive = false;
        }

        public async Task GoProduction(GoProductionInput input)
        {
            var task = await Repository.GetAsync(input.TaskId);
            task.GoProduction(input.Quantity);
        }
    }

    public class MainTaskAppService : TaskAppService<MainTask>, IMainTaskAppService
    {
        public MainTaskAppService(IRepository<MainTask, long> repository) : base(repository)
        {
        }
    }

    public class SideTaskAppService : TaskAppService<SideTask>, ISideTaskAppService
    {
        public SideTaskAppService(IRepository<SideTask, long> repository) : base(repository)
        {
        }
    }
}
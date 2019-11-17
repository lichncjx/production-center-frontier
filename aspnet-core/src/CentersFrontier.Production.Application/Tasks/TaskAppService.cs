using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using CentersFrontier.Production.Tasks.Dto;

namespace CentersFrontier.Production.Tasks
{
    public class TaskAppService<TTask> : AsyncCrudAppService<TTask, TaskDto, long, PagedTaskResultRequestDto, CreateTaskDto, TaskDto>, ITaskAppService
    where TTask : ManufacturingTask
    {
        public TaskAppService(IRepository<TTask, long> repository) : base(repository)
        {
        }

        public Task ActivateTask(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeactivateTask(long id)
        {
            throw new System.NotImplementedException();
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
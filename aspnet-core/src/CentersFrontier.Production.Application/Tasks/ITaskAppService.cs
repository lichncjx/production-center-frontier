using Abp.Application.Services;

namespace CentersFrontier.Production.Tasks
{
    public interface ITaskAppService : IApplicationService
    {
        
    }

    public class TaskAppService : ApplicationService, ITaskAppService
    {
    }

    public interface IMainTaskAppService : ITaskAppService
    {

    }

    public interface ISubTaskAppService : ITaskAppService
    {

    }

    public interface ISideTaskAppService : ITaskAppService
    {

    }
}
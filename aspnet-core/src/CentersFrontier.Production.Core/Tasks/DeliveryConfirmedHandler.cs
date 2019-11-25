using System.Linq;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus.Handlers;
using CentersFrontier.Production.Tasks.Events;
using Microsoft.EntityFrameworkCore;

namespace CentersFrontier.Production.Tasks
{
    public class DeliveryConfirmedHandler : IAsyncEventHandler<DeliveryConfirmed>, ITransientDependency
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<ManufacturingTask, long> _taskRepository;
        private readonly IRepository<ManufacturingBatch, long> _batchRepository;

        public DeliveryConfirmedHandler(IUnitOfWorkManager unitOfWorkManager, IRepository<ManufacturingTask, long> taskRepository, IRepository<ManufacturingBatch, long> batchRepository)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _taskRepository = taskRepository;
            _batchRepository = batchRepository;
        }

        public async Task HandleEventAsync(DeliveryConfirmed eventData)
        {
            using (var uow = _unitOfWorkManager.Begin())
            {
                var batch = await _batchRepository.GetAsync(eventData.BatchId);
                batch.Complete();
                await uow.CompleteAsync();
            }

            using (var uow = _unitOfWorkManager.Begin())
            {
                var task = await _taskRepository.GetAllIncluding(t => t.Batches).SingleAsync(t => t.Id == eventData.TaskId);
                if(task.Batches.All(b => b.IsCompleted))
                    task.Complete();
                await uow.CompleteAsync();
            }
        }
    }
}
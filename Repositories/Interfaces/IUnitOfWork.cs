using MicroelectronicsWarehouse.Entities;

namespace MicroelectronicsWarehouse.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Supplier> Suppliers { get; }
        IGenericRepository<Component> Components { get; }

        Task<int> CompleteAsync(); // SaveChanges
    }
}

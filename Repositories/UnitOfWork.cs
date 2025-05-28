using MicroelectronicsWarehouse.Data;
using MicroelectronicsWarehouse.Entities;
using MicroelectronicsWarehouse.Repositories.Interfaces;

namespace MicroelectronicsWarehouse.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IGenericRepository<Category> Categories { get; private set; }
        public IGenericRepository<Supplier> Suppliers { get; private set; }
        public IGenericRepository<Component> Components { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Categories = new GenericRepository<Category>(context);
            Suppliers = new GenericRepository<Supplier>(context);
            Components = new GenericRepository<Component>(context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}

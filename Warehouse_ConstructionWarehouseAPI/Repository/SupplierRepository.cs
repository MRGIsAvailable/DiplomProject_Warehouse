using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Warehouse_ConstructionWarehouseAPI.Data;
using Warehouse_ConstructionWarehouseAPI.Models;
using Warehouse_ConstructionWarehouseAPI.Repository.IRepository;

namespace Warehouse_ConstructionWarehouseAPI.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private readonly ApplicationDbContext _db;
        public SupplierRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<Supplier> UpdateAsync(Supplier entity)
        {
            _db.Suppliers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Warehouse_ConstructionWarehouseAPI.Data;
using Warehouse_ConstructionWarehouseAPI.Models;
using Warehouse_ConstructionWarehouseAPI.Repository.IRepository;

namespace Warehouse_ConstructionWarehouseAPI.Repository
{
    public class SupplierProductRepository : Repository<SupplierProduct>, ISupplierProductRepository
    {
        private readonly ApplicationDbContext _db;
        public SupplierProductRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<SupplierProduct> UpdateAsync(SupplierProduct entity)
        {
            _db.SupplierProducts.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}

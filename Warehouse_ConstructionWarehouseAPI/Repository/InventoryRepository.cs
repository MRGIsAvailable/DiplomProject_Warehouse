using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Warehouse_ConstructionWarehouseAPI.Data;
using Warehouse_ConstructionWarehouseAPI.Models;
using Warehouse_ConstructionWarehouseAPI.Repository.IRepository;

namespace Warehouse_ConstructionWarehouseAPI.Repository
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        private readonly ApplicationDbContext _db;
        public InventoryRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<Inventory> UpdateAsync(Inventory entity)
        {
            _db.Inventory.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}

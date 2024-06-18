using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Warehouse_ConstructionWarehouseAPI.Data;
using Warehouse_ConstructionWarehouseAPI.Models;
using Warehouse_ConstructionWarehouseAPI.Repository.IRepository;

namespace Warehouse_ConstructionWarehouseAPI.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<Order> UpdateAsync(Order entity)
        {
            _db.Orders.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}

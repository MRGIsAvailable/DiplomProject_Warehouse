using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Warehouse_ConstructionWarehouseAPI.Data;
using Warehouse_ConstructionWarehouseAPI.Models;
using Warehouse_ConstructionWarehouseAPI.Repository.IRepository;

namespace Warehouse_ConstructionWarehouseAPI.Repository
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        private readonly ApplicationDbContext _db;
        public StatusRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<Status> UpdateAsync(Status entity)
        {
            _db.Statuses.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}

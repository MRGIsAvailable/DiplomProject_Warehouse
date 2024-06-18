using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Warehouse_ConstructionWarehouseAPI.Data;
using Warehouse_ConstructionWarehouseAPI.Models;
using Warehouse_ConstructionWarehouseAPI.Repository.IRepository;

namespace Warehouse_ConstructionWarehouseAPI.Repository
{
    public class PremiseRepository : Repository<Premise>, IPremiseRepository
    {
        private readonly ApplicationDbContext _db;
        public PremiseRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<Premise> UpdateAsync(Premise entity)
        {
            _db.Premises.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}

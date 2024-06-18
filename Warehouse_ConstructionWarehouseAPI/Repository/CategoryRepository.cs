using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Warehouse_ConstructionWarehouseAPI.Data;
using Warehouse_ConstructionWarehouseAPI.Models;
using Warehouse_ConstructionWarehouseAPI.Repository.IRepository;

namespace Warehouse_ConstructionWarehouseAPI.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            _db.Categories.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}

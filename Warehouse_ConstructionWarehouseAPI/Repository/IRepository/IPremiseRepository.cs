﻿using System.Linq.Expressions;
using Warehouse_ConstructionWarehouseAPI.Models;

namespace Warehouse_ConstructionWarehouseAPI.Repository.IRepository
{
    public interface IPremiseRepository : IRepository<Premise>
    {
        Task<Premise> UpdateAsync(Premise entity);
    }
}

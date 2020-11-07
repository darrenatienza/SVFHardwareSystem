﻿using AutoMap;
using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services
{
    public class SupplierService : Service<SupplierModel, Supplier>, ISupplierService
    {
        public async Task<IList<SupplierModel>> GetAllAsync(string criteria)
        {
            using (var db = new DataContext())
            {
                var suppliers = await db.Suppliers.Where(x => x.Name.Contains(criteria)).ToListAsync();
                var models = Mapping.Mapper.Map<List<SupplierModel>>(suppliers);
                return models;
            }
        }
    }
}

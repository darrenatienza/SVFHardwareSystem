using AutoMap;
using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services
{
    public class CategoryService : Service<CategoryModel,Category>,ICategoryService
    {

        public CategoryService()
        {
           
        }
        public async Task<IList<CategoryModel>> GetAllAsync(string criteria)
        {
            using (var db = new DataContext())
            {
                List<Category> objs = await db.Categories.Where(x => x.Name.Contains(criteria)).ToListAsync();
                var models = Mapping.Mapper.Map<List<CategoryModel>>(objs);
                return models;
            }
        }
    }
}

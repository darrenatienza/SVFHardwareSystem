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
    public class CategoryService : ICategoryService
    {

        public CategoryService()
        {
           
        }

        public async Task<int> Add(CategoryModel obj)
        {
            using (var db = new DataContext())
            {
                var category = Mapping.Mapper.Map<Category>(obj);
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return category.CategoryID;
            }
        }

       

        public async Task<int> Edit(int id, CategoryModel obj)
        {
            using (var db = new DataContext())
            {
                var entity = db.Categories.Find(id);
                var category = Mapping.Mapper.Map(obj,entity);
                db.Entry(category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return category.CategoryID;
            }
        }

        public async Task<CategoryModel> Get(int id)
        {
            using (var db = new DataContext())
            {
                var obj = db.Categories.Find(id);
                var model = obj != null ? Mapping.Mapper.Map<CategoryModel>(obj) : throw new KeyNotFoundException();
                return model;
            }
        }

        public async Task<IList<CategoryModel>> GetAll()
        {
            using (var db = new DataContext())
            {
                List<Category> objs = await db.Categories.ToListAsync();
                var models = Mapping.Mapper.Map<List<CategoryModel>>(objs);
                return models;
            }
        }

        public async Task<IList<CategoryModel>> GetAll(string criteria)
        {
            using (var db = new DataContext())
            {
                List<Category> objs = await db.Categories.Where(x => x.Name.Contains(criteria)).ToListAsync();
                var models = Mapping.Mapper.Map<List<CategoryModel>>(objs);
                return models;
            }
        }

        public async Task Remove(int id)
        {
            using (var db = new DataContext())
            {
                var entity = db.Categories.Find(id);
                db.Categories.Remove(entity);
                await db.SaveChangesAsync();
            }
        }
    }
}

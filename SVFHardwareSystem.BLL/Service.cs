using AutoMap;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Exceptions;
using SVFHardwareSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Services
{
    /// <summary>
    /// Base Service class
    /// </summary>
    /// <typeparam name="TModel">Service Model</typeparam>
    /// <typeparam name="TEntity">Data Entity</typeparam>
    public class Service<TModel,TEntity> : IService<TModel> where TModel : class where TEntity : class
    {
        public  virtual async Task AddAsync(TModel model)
        {
            using (var db = new DataContext())
            {
                var entity = Mapping.Mapper.Map<TEntity>(model);
                db.Set<TEntity>().Add(entity);
                await db.SaveChangesAsync();
            }
        }

        public virtual async Task<TModel> AddNewAsync(TModel model)
        {
            using (var db = new DataContext())
            {
                var entity = Mapping.Mapper.Map<TEntity>(model);
                db.Set<TEntity>().Add(entity);
                await db.SaveChangesAsync();
                return Mapping.Mapper.Map<TModel>(entity);
            }
        }

        public virtual async Task EditAsync(int id, TModel model)
        {
            using (var db = new DataContext())
            {
                var entity = await db.Set<TEntity>().FindAsync(id);
                var newEntity = Mapping.Mapper.Map(model, entity);
                db.Entry(newEntity).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }

        public async Task<TModel> GetAsync(int id)
        {
            using (var db = new DataContext())
            {
                var entity = await db.Set<TEntity>().FindAsync(id);
                var model = entity != null ? Mapping.Mapper.Map<TModel>(entity) : throw new RecordNotFoundException();
                return model;
            }
        }

        public async Task<IList<TModel>> GetAllAsync()
        {
            using (var db = new DataContext())
            {
                List<TEntity> entities = await db.Set<TEntity>().ToListAsync();
                var models = Mapping.Mapper.Map<List<TModel>>(entities);
                return models;
            }
        }

        public virtual async Task RemoveAsync(int id)
        {
            using (var db = new DataContext())
            {
                var entity = await db.Set<TEntity>().FindAsync(id);
                db.Set<TEntity>().Remove(entity);
                await db.SaveChangesAsync();
            }
        }

        public virtual TModel Get(int id)
        {
            using (var db = new DataContext())
            {
                var entity = db.Set<TEntity>().Find(id);
                var model = entity != null ? Mapping.Mapper.Map<TModel>(entity) : throw new RecordNotFoundException();
                return model;
            }
        }

        public IList<TModel> GetAll()
        {
            using (var db = new DataContext())
            {
                List<TEntity> entities = db.Set<TEntity>().ToList();
                var models = Mapping.Mapper.Map<List<TModel>>(entities);
                return models;
            }
        }
    }
}

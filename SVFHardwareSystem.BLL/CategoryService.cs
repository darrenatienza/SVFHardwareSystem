using AutoMap;
using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Queries;
using SVFHardwareSystem.Services.Interfaces;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
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

        public Task<int> Add(CategoryModel obj)
        {
            throw new NotImplementedException();
        }

        public int Edit(int id, CategoryModel obj)
        {
            throw new NotImplementedException();
        }

        public CategoryModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<CategoryModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

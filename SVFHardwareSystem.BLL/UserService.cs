using AutoMap;
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
    public class UserService : Service<UserModel, User>, IUserService
    {
        public async Task<UserModel> Get(string userName)
        {
            using (var db = new DataContext())
            {
                var user = await db.Users.FirstOrDefaultAsync(x => x.UserName == userName);
                var model = Mapping.Mapper.Map<UserModel>(user);
                return model;
            }
        }
    }
}

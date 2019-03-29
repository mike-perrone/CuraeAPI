using FiralApiReal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiralApiReal.Data
{
   public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class; // addding photos or users(entities)
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll(); // saving changes will check if the database has changes tht need to be saved
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}

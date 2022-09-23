using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using api.Models;

namespace api.Repo.Interface
{
    public interface IDogRepository
    {
        void add<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveAll();

      Task<Dog> AddDog(DogForCreation field);
      Task<IEnumerable<Dog>> GetDogs();
      Task<IEnumerable<object>> GetDogWithId(int Id);
      Task<IEnumerable<object>> GetDogWithName(string name);
      Task<Dog> UpdateDog(DogForUpdate model);
      Task <bool> DeleteDog(int id);
    }
}
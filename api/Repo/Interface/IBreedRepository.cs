using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using api.Models;

namespace api.Repo.Interface
{
    public interface IBreedRepository
    {
       void add<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveAll();

      Task<Breed> AddBreed(BreedForCreation field);
      Task<IEnumerable<Breed>> GetBreeds();
      Task<IEnumerable<object>> GetBreedWithId(int Id);
      Task<IEnumerable<object>> GetBreedWithName(string name);
      Task<Breed> UpdateBreed(BreedForUpdate model);
      Task <bool> DeleteBreed(int id); 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto;
using api.Models;
using api.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace api.Repo
{
  public class BreedRepository : IBreedRepository
  {
    private readonly DataContext context;

    public BreedRepository(DataContext context)
    {
      this.context = context;
    }

    public void add<T>(T entity) where T : class
    {
      context.Add(entity);
    }

    public async Task<Breed> AddBreed(BreedForCreation field)
    {
      var data = new Breed

      {
        Name = field.Name,
        Size = field.Size,
        Friendliness = field.Friendliness,
        Trainability = field.Trainability,
        Sheddingamount = field.Sheddingamount,
        Exerciseneeds = field.Exerciseneeds
      };

      await context.Breeds.AddAsync(data);
      await SaveAll();
      return data;
    }

    public void Delete<T>(T entity) where T : class
    {
      context.Remove(entity);
    }

    public async Task<bool> DeleteBreed(int id)
    {
      var dataFromRepo = await context.Breeds.FirstOrDefaultAsync(a => a.Id == id);
      if (dataFromRepo != null)
      {
        context.Breeds.Remove(dataFromRepo);
        await SaveAll();
        return true;
      }
      return false;
    }

    public async Task<IEnumerable<Breed>> GetBreeds()
    {
      var dataFromRepo = await context.Breeds.ToListAsync();
      return dataFromRepo;
    }

    public async Task<IEnumerable<object>> GetBreedWithId(int Id)
    {
      var dataFromRepo = await context.Breeds.Where(x => x.Id == Id).ToListAsync();
      return dataFromRepo;
    }

    public async Task<IEnumerable<object>> GetBreedWithName(string name)
    {
      var dataFromRepo = await context.Breeds.Where(x => x.Name == name).ToListAsync();
      return dataFromRepo;
    }

    public async Task<bool> SaveAll()
    {
      return await context.SaveChangesAsync() > 0;
    }

    public async Task<Breed> UpdateBreed(BreedForUpdate model)
    {
      var data = await context.Breeds.FirstOrDefaultAsync(i => i.Id == model.Id);
      if (data == null)
      {
        return null;
      }

      data.Name = model.Name;
      data.Id = model.Id;
      data.Size = model.Size;
      data.Friendliness = model.Friendliness;
      data.Trainability = model.Trainability;
      data.Sheddingamount = model.Sheddingamount;
      data.Exerciseneeds = model.Exerciseneeds;
      await SaveAll();

      return data;
    }
  }
}
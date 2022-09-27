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
  public class DogRepository : IDogRepository
  {
    private readonly DataContext context;

    public DogRepository(DataContext context)
    {
      this.context = context;
    }
    public void add<T>(T entity) where T : class
    {
      context.Add(entity);
    }

    public async Task<Dog> AddDog(DogForCreation field)
    {
      var data = new Dog

      {
        BreedId = field.BreedId,
        Name = field.Name,
        Age = field.Age,
        gender = field.gender,
        Color = field.Color,
        FavouriteFood = field.FavouriteFood,
        FavouriteToy = field.FavouriteToy
      };

      await context.Dogs.AddAsync(data);
      await SaveAll();
      return data;
    }

    public void Delete<T>(T entity) where T : class
    {
      context.Remove(entity);
    }

    public async Task<bool> DeleteDog(int id)
    {
      var dataFromRepo = await context.Dogs.FirstOrDefaultAsync(a => a.Id == id);
      if (dataFromRepo != null)
      {
        context.Dogs.Remove(dataFromRepo);
        await SaveAll();
        return true;
      }
      return false;
    }

    public async Task<IEnumerable<Dog>> GetDogs()
    {
      var dataFromRepo = await context.Dogs.ToListAsync();
      return dataFromRepo;
    }

    public async Task<IEnumerable<object>> GetDogWithId(int Id)
    {
      var dataFromRepo = await context.Dogs
      .Include(a => a.Breed)
      .Where(x => x.Id == Id).ToListAsync();
      return dataFromRepo;
    }

    public async Task<IEnumerable<object>> GetDogWithName(string name)
    {
      var dataFromRepo = await context.Dogs.Where(x => x.Name == name).ToListAsync();
      return dataFromRepo;
    }

    public async Task<bool> SaveAll()
    {
      return await context.SaveChangesAsync() > 0;
    }

    public async Task<Dog> UpdateDog(DogForUpdate model)
    {
      var data = await context.Dogs.FirstOrDefaultAsync(i => i.Id == model.Id);
      if (data == null)
      {
        return null;
      }

      data.Name = model.Name;
      data.Age = model.Age;
      data.gender = model.gender;
      data.Color = model.Color;
      data.FavouriteFood = model.FavouriteFood;
      data.FavouriteToy = model.FavouriteToy;
      await SaveAll();

      return data;
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using api.Models;
using AutoMapper;

namespace api.Helper
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Dog, DogForCreation>();
      CreateMap<DogForCreation, Dog>();

      CreateMap<Dog, DogForGet>();
      CreateMap<DogForGet, Dog>();
    }
  }

}
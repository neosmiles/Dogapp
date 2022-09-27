using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using api.Repo.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DogController : ControllerBase
  {
    private readonly IDogRepository dogRepository;
    private readonly IMapper mapper;

    public DogController(IDogRepository dogRepository, IMapper mapper)
    {
      this.dogRepository = dogRepository;
      this.mapper = mapper;
    }

    [HttpPost]
    public async
    Task<IActionResult> AddDog([FromBody] DogForCreation field)
    {
      var dataFromRepo = await dogRepository.AddDog(field);
      if (dataFromRepo == null)
      {
        return BadRequest
        (new
        {
          message = "Error",
          StatusCode = 401,
          isSuccessful = false
        });
      }

      return Ok(new
      {
        Message = "Success",
        StatusCode = 201,
        IsSuccessful = true,
        Data = dataFromRepo
      });
    }

    [HttpGet]
    public async Task<ActionResult<DogForGet>> getDog()
    {
      var dataFromRepo = await dogRepository.GetDogs();
      if (dataFromRepo == null)
      {
        return BadRequest
        (new
        {
          Message = "Error",
          StatusCode = 401,
          IsSuccessful = false
        });
      }

      return Ok(new
      {
        Message = "Success",
        StatusCode = 201,
        IsSuccessful = true,
        Data = mapper.Map<ICollection<DogForGet>>(dataFromRepo)
      });
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> getDogWithId(int id)
    {
      var dataFromRepo = await dogRepository.GetDogWithId(id);
      if (dataFromRepo == null)
      {
        return BadRequest(new
        {
          Message = "Error",
          StatusCode = 401,
          IsSuccessful = false
        });
      }

      return Ok(new
      {
        Message = "Success",
        StatusCode = 200,
        IsSuccessful = true,
        AuthorId = id,
        data = mapper.Map<ICollection<DogForReturn>>(dataFromRepo)
      });
    }

    [HttpGet]
    [Route("name")]
    public async Task<IActionResult> getDogWithName(String name)
    {
      var dataFromRepo = await dogRepository.GetDogWithName(name);
      if (dataFromRepo == null)
      {
        return BadRequest(new
        {
          Message = "Error",
          StatusCode = 401,
          IsSuccessful = false
        });
      }

      return Ok(new
      {
        Message = "Success",
        StatusCode = 201,
        IsSuccessful = true,
        data = mapper.Map<ICollection<DogForGet>>(dataFromRepo)
      });
    }


    [HttpPost("Update")]
    public async Task<IActionResult> UpdateDog(DogForUpdate model)
    {
      var dataFromRepo = await dogRepository.UpdateDog(model);
      if (dataFromRepo == null)
      {
        return BadRequest(new
        {
          Message = "Error",
          StatusCode = 401,
          IsSuccessful = false
        });
      }

      return Ok(new
      {
        Message = "Success",
        StatusCode = 201,
        IsSuccessful = true,
        data = dataFromRepo
      });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteDog(int id)
    {
      var dataFromRepo = await dogRepository.DeleteDog(id);
      if (!ModelState.IsValid)
        return BadRequest(new
        {
          Message = "Error",
          StatusCode = 401,
          IsSuccessful = false
        });

      return Ok(new
      {
        Message = "Dog deleted",
        StatusCode = 201,
        IsSuccessful = true,
        PostId = id,
        dataFromRepo
      });
    }
  }
}
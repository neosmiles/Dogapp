using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using api.Repo;
using api.Repo.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BreedController : ControllerBase
  {
    private readonly IBreedRepository breedRepository;
    private readonly IMapper mapper;

    public BreedController(IBreedRepository breedRepository, IMapper mapper)
    {
      this.breedRepository = breedRepository;
      this.mapper = mapper;
    }

    [HttpPost]
    public async
  Task<IActionResult> AddBreed([FromBody] BreedForCreation field)
    {
      var dataFromRepo = await breedRepository.AddBreed(field);
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
    public async Task<ActionResult<BreedForGet>> getBreed()
    {
      var dataFromRepo = await breedRepository.GetBreeds();
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
        Data = mapper.Map<ICollection<BreedForGet>>(dataFromRepo)
      });
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> getBreedWithId(int id)
    {
      var dataFromRepo = await breedRepository.GetBreedWithId(id);
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
        data = dataFromRepo
      });
    }

    [HttpGet]
    [Route("name")]
    public async Task<IActionResult> getBreedWithName(String name)
    {
      var dataFromRepo = await breedRepository.GetBreedWithName(name);
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
        data = mapper.Map<ICollection<BreedForGet>>(dataFromRepo)
      });
    }


    [HttpPost("Update")]
    public async Task<IActionResult> UpdateBreed(BreedForUpdate model)
    {
      var dataFromRepo = await breedRepository.UpdateBreed(model);
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
    public async Task<IActionResult> deleteBreed(int id)
    {
      var dataFromRepo = await breedRepository.DeleteBreed(id);
      if (!ModelState.IsValid)
        return BadRequest(new
        {
          Message = "Error",
          StatusCode = 401,
          IsSuccessful = false
        });

      return Ok(new
      {
        Message = "Breed deleted",
        StatusCode = 201,
        IsSuccessful = true,
        PostId = id,
        dataFromRepo
      });
    }

  }
}
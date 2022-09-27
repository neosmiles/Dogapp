using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
  public class DogForReturn
  {
    public string Name { get; set; }
    public int Id { get; set; }
    public int Age { get; set; }
    public int BreedId { get; set; }
    public string gender { get; set; }
    public string Color { get; set; }
    public string FavouriteFood { get; set; }
    public string FavouriteToy { get; set; }
    public BreedNameDto Breed { get; set; }
  }
}
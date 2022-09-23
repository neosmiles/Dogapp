using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Models
{
  public class Breed
  {
    public string Name { get; set; }
    public int Id { get; set; }

    public string Size { get; set; }

    [Range(1, 5)]
    public int Friendliness { get; set; }
    [Range(1, 5)]
    public int Trainability { get; set; }
    [Range(1, 5)]
    public int Sheddingamount { get; set; }
    [Range(1, 5)]
    public int Exerciseneeds { get; set; }

    public Dog Dog { get; set; }
  }
}
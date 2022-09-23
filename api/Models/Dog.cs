using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Dog
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
        public int BreedId { get; set; }
        public string gender { get; set; }
        public string Color { get; set; }
        public string FavouriteFood { get; set; }
        public string FavouriteToy { get; set; }

        public ICollection<Breed> Breeds { get; set; }
    }
}
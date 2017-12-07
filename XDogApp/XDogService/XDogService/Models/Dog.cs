using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XDogService.Models
{
    public class Dog
    {

        public string MainOwnerId { get; set; }
        public string MainOwnerUserId { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
        public int AgeRangeMin { get; set; }
        public string CurrentTown { get; set; }
        public List<string> Interests { get; set; }
        public string Bio { get; set; }
        public DateTime DOB { get; set; }

    }
}
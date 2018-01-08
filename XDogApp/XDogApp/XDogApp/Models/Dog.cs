using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XDogApp.ServiceData;

namespace XDogApp.Models
{
    public class Dog : BaseId
    {
        //public string MainOwnerId { get; set; }

        //public string PPPath { get; set; }
        //public string Name { get; set; }
        public string Breed { get; set; }
        //public string Gender { get; set; }
        //public string Bio { get; set; }
        //public DateTime DOB { get; set; }
    }

    public class Dog2 : BaseId
    {
        public string MainOwnerId { get; set; }

        public string PPPath { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }
        public string Bio { get; set; }
        public DateTime DOB { get; set; }
    }
}

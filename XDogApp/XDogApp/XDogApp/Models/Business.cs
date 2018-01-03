using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XDogApp.ServiceData;

namespace XDogApp.Models
{
    public class Business : BaseId
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Bio { get; set; }
        public string OpeningTimes { get; set; }
        public DateTime DOB { get; set; }
    }
}

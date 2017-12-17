using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XDogApp.ServiceData;

namespace XDogApp.Models
{

    public class TodoItem : BaseId
    {
        //[JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        //[JsonProperty(PropertyName = "complete")]
        //public bool Complete { get; set; }
    }
}

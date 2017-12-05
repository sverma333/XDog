using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace XDogApp.Models
{
    public class BaseAzureData 
    {
        public string Id { get; set; }
    }

    public class TodoItem : BaseAzureData
    {
        public string Text { get; set; }
        public bool Complete { get; set; }
    }
}

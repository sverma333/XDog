using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace XDogApp.Models
{
    public class BaseAzureData 
    {
        public BaseAzureData() { }
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public class TodoItem : BaseAzureData
    {
        public TodoItem() : base() { }

        public bool Complete { get; set; }
    }
}

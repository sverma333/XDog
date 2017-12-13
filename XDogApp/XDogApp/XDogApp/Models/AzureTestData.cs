using ClientServerData.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace XDogApp.Models
{

    public class TodoItem : BaseId
    {
        public string Text { get; set; }
        public bool Complete { get; set; }
    }
}

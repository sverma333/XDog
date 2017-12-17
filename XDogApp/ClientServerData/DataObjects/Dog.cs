using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientServerData.DataObjects
{
    public class Dog : BaseId
    {

        public string MainOwnerId { get; set; }
        public string MainOwnerUserId { get; set; }

        public string Name { get; set; }
        //public List<string> Interests { get; set; }
        public string Bio { get; set; }
        public DateTime DOB { get; set; }

    }
}
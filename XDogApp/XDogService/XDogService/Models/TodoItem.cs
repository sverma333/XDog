using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XDogService.Models
{
    public class TodoItem : EntityData
    {

        //[Required]
        public string Text { get; set; }
        //public bool Complete { get; set; }
    }
}
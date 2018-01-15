using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDogApp.Menu
{
    public class MenuItem
    {
		public string Title { get; set; }
		public Type TargetType { get; set; }
		public string Icon { get; set; }
        public bool HasIcon { get { return !String.IsNullOrEmpty(Icon); }}
    }
}

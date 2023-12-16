using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Classes
{
    public class Card:Magic
    {
        public Uri ImageUrl { get; set; }
        override public string ToString()
        {
            return Name;
        }
    }
}

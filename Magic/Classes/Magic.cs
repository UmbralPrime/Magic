using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Classes
{
    public class Magic
    {
        public string Name { get; set; }
        [Key]
        public string Id { get; set; }
    }
}

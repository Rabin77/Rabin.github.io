using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ghardailo.Models
{
    public class manager
    {
        [Key]
        public int id { get; set; }

        public string userName { get; set; }
        public string userPassword { get; set; }
    }
}

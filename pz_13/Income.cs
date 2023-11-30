using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_13
{
    internal class Income
    {
        [Key]
        public int id { get; set; }
        public string point { get; set; }
        public string date { get; set; }
        public string inc { get; set; }
        public Income() { }
    }
}

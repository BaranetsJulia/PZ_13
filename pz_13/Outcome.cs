using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_13
{
    internal class Outcome
    {
        [Key]
        public int id { get; set; }
        public string point { get; set; }
        public string date { get; set; }
        public string out_ { get; set; }
        public Outcome() { }
    }
}


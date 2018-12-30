using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcAppUg.Models
{
    public class Donkey
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public int Experience { get; set; }

        private bool isPregnant { get; set; }
    }
}

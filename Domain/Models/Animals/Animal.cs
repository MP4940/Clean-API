using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Animals
{
    public class Animal
    {
        public Guid AnimalID { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}

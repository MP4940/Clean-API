using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Animals;

namespace Domain.Models.Animals.Dogs
{
    public class Dog : Animal
    {
        public string Bark()
        {
            return "Bark";
        }
    }
}

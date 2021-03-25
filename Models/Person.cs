using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } // имя пользователя

        public int Test { get; set; }
        public int Age { get; set; } // возраст пользователя

        public List<Systems> linkedSystems;

        public List<Process> linkedProcess;

        //public ICollection<Process> Processes { get; set; }

    }
}

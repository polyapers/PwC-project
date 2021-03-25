using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Process
    {
        public int Id { get; set; }

        public List<Systems> linkedSystems;

        public List<Person> linkedPersons;

        public string dataComposition;

        public string monetaryRightsSubjects;

        public string processBasis;

        //public Person Person { get; set; }
    }
}

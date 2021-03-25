using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Systems
    {
        public int Id { get; set; }

        List<Person> linkedPersosns;

        string SystemHosting;

        string SystemOwner;
    }
}

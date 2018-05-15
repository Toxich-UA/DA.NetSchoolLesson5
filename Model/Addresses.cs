using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson4.Entity;

namespace Lesson4.Model
{
    public partial class Addresses
    {
        public int ClientId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public Clients Client { get; set; }
    }
}

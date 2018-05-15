using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson4.Entity;

namespace Lesson4.Model
{
    public partial class Cards
    {
        public Cards()
        {
            InOperations = new List<Operations>();
            OutOperations = new List<Operations>();
        }

        public string CardId { get; set; }
        public string PinCode { get; set; }
        public decimal Ballance { get; set; }
        
        public int ClientId { get; set; }
        public List<Operations> InOperations { get; set; }
        public List<Operations> OutOperations { get; set; }

        public Clients Client { get; set; }
    }
}

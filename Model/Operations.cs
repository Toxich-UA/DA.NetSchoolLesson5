using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4.Model
{
    public partial class Operations
    {
        public long OperationId { get; set; }
        public string InId { get; set; }
        public string OutId { get; set; }
    
        public decimal Amount { get; set; }
        
        public DateTime OperationTime { get; set; }

        public Cards InCard { get; set; }
        public Cards OutCard { get; set; }
    }
}

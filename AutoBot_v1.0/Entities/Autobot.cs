using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Autobot
    {
        public int Id { get; set; }
        public string Indexes { get; set; }
        public string Action { get; set; }
        public DateTime? ActionDate { get; set; }
        public string Except { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsUpdated { get; set; }
    }

    public class IndexesObj
    {
        public string Indexes { get; set; }
        public string returnValue { get; set; }
        public string ActionResponse { get; set; }
    }


}

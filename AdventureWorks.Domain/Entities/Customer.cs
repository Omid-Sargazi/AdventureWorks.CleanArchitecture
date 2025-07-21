using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Domain.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }//PK
        public int? PersonID { get; set; }//FK 

        public Person? Person { get; set; }
        public ICollection<SalesOrderHeader> Orders { get; set; } = new List<SalesOrderHeader>();   
    }
}

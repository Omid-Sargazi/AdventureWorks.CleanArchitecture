using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Application.Features.Products.Queries.GetMonthlySales
{
    public class MonthlySalesDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int TotalOrder { get; set; }
        public int TotalQty { get; set; }
    }
}

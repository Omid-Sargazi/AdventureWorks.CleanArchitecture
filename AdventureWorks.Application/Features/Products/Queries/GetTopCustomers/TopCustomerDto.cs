using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Application.Features.Products.Queries.GetTopCustomers
{
    public class TopCustomerDto
    {
        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public decimal TotalSales { get; set; }
    }
}

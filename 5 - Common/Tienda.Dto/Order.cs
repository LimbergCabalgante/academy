using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Dto
{
    public class Order
    {
        public int Id { get; set; }
        public string BillingNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UserId { get; set; }
        public int StatusId { get; set; }
        public decimal TotalPrice { get; set; }
        public string UserFullName { get; set; }
    }
}

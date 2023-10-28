using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users.Sales.Payments
{
    public class SalePayment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Sale")]
        public int? SaleId { get; set; }
        public  Sale Sale { get; set; }
            
    }
}

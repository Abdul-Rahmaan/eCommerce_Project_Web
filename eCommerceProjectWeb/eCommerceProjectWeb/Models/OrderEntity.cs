using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceProjectWeb.Models
{
    public class OrderEntity
    {
        [Key]

        public int OrderId { get; set; }

        public int ProId { get; set; }

        [NotMapped]

        public string ProName { get; set; }

        public int CostId { get; set; }

        [NotMapped]

        public string CostName { get; set; }

        public int SellerId { get; set; }

        [NotMapped]

        public string SellerName { get; set; }

        public int OrderTotal { get; set; }

        public string OrderStatus { get; set; }

        public string PaymentStatus { get; set; }

        public string OrderDate { get; set; }

       

    }
}

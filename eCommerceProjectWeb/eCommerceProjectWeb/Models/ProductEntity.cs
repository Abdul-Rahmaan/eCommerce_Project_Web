using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceProjectWeb.Models
{
    public class ProductEntity
    {
        [Key]

        public int ProId { get; set; }

        public string ProName { get; set; }

        public int ProQuantity { get; set; }

        public int ProPrice { get; set; }

        public string ProCategory { get; set; }

        public int SellerId { get; set; }

        [NotMapped]
        public string SellerName { get; set; }
    }

}

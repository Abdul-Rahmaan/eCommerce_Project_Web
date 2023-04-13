using System.ComponentModel.DataAnnotations;

namespace eCommerceProjectWeb.Models
{
    public class SellerEntity
    {
        [Key]

        public int SellerId { get; set; }

        public string SellerName { get; set; }

        public string SellerPhone { get; set;}

        public string SellerAddress { get;set; }

        public string SellerCNIC { get; set; }

        public string SellerEmail { get; set; }
    }
}

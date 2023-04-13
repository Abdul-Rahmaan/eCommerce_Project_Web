using System.ComponentModel.DataAnnotations;

namespace eCommerceProjectWeb.Models
{
    public class CustomerEntity
    {
        [Key]
        public int CostId { get; set; }

        public string CostName { get; set; }

        public string CostAddress { get; set; }

        public string CostContact { get; set; }

        public string CostCNIC { get; set; }

        public string CostEmail { get; set; }
    }
}

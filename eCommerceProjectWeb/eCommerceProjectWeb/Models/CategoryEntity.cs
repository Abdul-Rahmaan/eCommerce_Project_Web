using System.ComponentModel.DataAnnotations;

namespace eCommerceProjectWeb.Models
{
    public class CategoryEntity
    {
        [Key]

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}

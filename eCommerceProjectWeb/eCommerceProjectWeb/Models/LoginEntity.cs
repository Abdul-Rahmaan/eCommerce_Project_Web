using System.ComponentModel.DataAnnotations;

namespace eCommerceProjectWeb.Models
{
    public class LoginEntity
    {
        [Key]

        public int LoginId { get; set; }

        public string userName { get; set; }

        public string password { get; set; }
    }
}

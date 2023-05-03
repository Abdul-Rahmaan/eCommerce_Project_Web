using Microsoft.EntityFrameworkCore;

namespace eCommerceProjectWeb.Models
{
    public class ProjectDBAccess: DbContext
    {
        public ProjectDBAccess(DbContextOptions<ProjectDBAccess> options) : base(options)
        {

        }
        public DbSet<ProductEntity> tblProduct { get; set; }
        public DbSet<CategoryEntity> tblCategory { get; set; }
        public DbSet<CustomerEntity> tblCustomer { get; set; }
        public DbSet<SellerEntity> tblSeller { get; set; }
        public DbSet<OrderEntity> tblOrder { get; set; }

        public DbSet<LoginEntity> tblLogin{ get; set; }

    }
}

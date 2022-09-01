using eComerceWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace eComerceWebsite.Data
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options) // constructor
        {

        }

        public DbSet<Products> Products { get; set; } //property. Gets from database
        public DbSet <Member> MembersMembers { get; set; }



    }
}

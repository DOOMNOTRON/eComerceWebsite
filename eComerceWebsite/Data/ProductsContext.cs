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

        // I messed up and changed the Database table name from MemberMembers to Members
        // I created a massive problem. To fix restart Visual Studio.
        // Then set the Dbset name to the previous name then update.
        public DbSet <Member> Members { get; set; }



    }
}

using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class StoreContext : DbContext
    {
        //va a recibir unas opciones y se las va a pasar a su clase padre DBCONTEXT
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<Beer> Beers { get; set; }  
        public DbSet<Brand> Brands { get; set; }   

    }
}

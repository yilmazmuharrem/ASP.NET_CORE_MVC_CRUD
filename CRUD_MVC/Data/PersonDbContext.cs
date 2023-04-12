using CRUD_MVC.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC.Data
{
    public class PersonDbContext : DbContext
    {

        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            : base(options)
        {
        }

        /*    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {

                optionsBuilder.UseNpgsql("Host=localhost;Database=DbPerson;Username=postgres;Password=1195");

            }*/

        public DbSet<Person> Employees { get; set; }
    }
}

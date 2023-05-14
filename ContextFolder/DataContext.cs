using Microsoft.EntityFrameworkCore;
using module_20.Entities;

namespace module_20.ContextFolder
{
    public class DataContext: DbContext
    {
        public DbSet<Subscriber> Subscribers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                DataBase=PhoneBook;
                Trusted_Connection=True;"
                );
        }
    }
}

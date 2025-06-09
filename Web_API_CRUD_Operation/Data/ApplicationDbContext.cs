using Microsoft.EntityFrameworkCore;
using Web_API_CRUD_Operation.Models;

namespace Web_API_CRUD_Operation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet <Worker> worker { get; set; }
    }
}

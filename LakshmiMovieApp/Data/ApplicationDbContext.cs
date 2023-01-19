using LakshmiMovieApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LakshmiMovieApp.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options ):base(options)
        {
                
        }
        public DbSet<Category> Categories { get; set; }
    }
}

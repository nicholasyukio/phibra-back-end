using Microsoft.EntityFrameworkCore;
using Entry.Models;

namespace Entry.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<EntryInfo> EntryInfos { get; set; }
    }
}
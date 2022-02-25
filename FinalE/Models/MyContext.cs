using Microsoft.EntityFrameworkCore;

namespace FinalE.Models
{ 
    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<Participants> Participants { get; set; }
        
    }
}
using CommonLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BeWebApi01.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public DbSet<Accident> accident { get; set; }
        public DbSet<TodoItem> todoItem { get; set; }
        //public DbSet<Owner> Owner { get; set; }
        //public DbSet<Vehicle> Vehicle { get; set; }

    }
}

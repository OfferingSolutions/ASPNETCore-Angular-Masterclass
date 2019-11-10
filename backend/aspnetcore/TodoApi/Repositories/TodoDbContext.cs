using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Repositories 
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {

        }

        public DbSet<TodoEntity> TodoItems { get; set; }
    }
}

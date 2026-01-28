using Api.Taskfy.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Taskfy.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options): base(options)
        {
        }
        public DbSet<TaskModel> Task { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica todas as configurações do assembly atual
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

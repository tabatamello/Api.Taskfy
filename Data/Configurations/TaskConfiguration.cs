using Api.Taskfy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Taskfy.Data.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.ToTable("Task");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.DateCreate)
              .HasDefaultValueSql("getutcdate()");

            builder
                .Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(p => p.Description)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(p => p.IsCompleted)
                .IsRequired();
        }
    }
}

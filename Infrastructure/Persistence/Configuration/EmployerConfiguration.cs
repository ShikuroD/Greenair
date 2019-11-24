using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationCore.Entities;
namespace Infrastructure.Persistence.Configuration
{
    public class EmployerConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.HasBaseType<Person>();
            //builder.OwnsOne(m => m.Address);

            builder.Property(s => s.Salary).HasColumnType("decimal(18,2)");
            builder.Property(s => s.JobId).IsRequired();

            builder.HasOne<Job>(s => s.Job)
                .WithMany(a => a.Employers)
                .HasForeignKey(s => s.JobId);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBTraining
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Company> Companies { get; set; } = null!;
        readonly StreamWriter logStream = new StreamWriter("myLog.txt", true);
        public ApplicationContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {           
            optionsBuilder.UseSqlite("Data Source = D:\\\\.NET projects\\DBTraining\\DBTraining\\DatabaseOfTraining.db");
            optionsBuilder.LogTo(logStream.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);            
            modelBuilder.Entity<Country>();
            modelBuilder.Entity<Company>();
            modelBuilder.ApplyConfiguration(new CompanyConfigure());
            modelBuilder.Entity<User>(UserConfigure);
            
        }
        public void UserConfigure(EntityTypeBuilder<User> builder)
        {
            builder.HasCheckConstraint("FullAges", "FullAges > 0 AND FullAges < 120");
            builder.ToTable("Users");
            builder.Property(n => n.FirstName).HasMaxLength(50);           

            builder.HasData(
                new User { Id = 1, FirstName = "Genry", LastName = "Gustav", FullAges = 18 },
                new User { Id = 2, FirstName = "Bob", LastName = "Vatson", FullAges = 37 },
                new User { Id = 3, FirstName = "Nick", LastName = "Nelson", FullAges = 25 });
        }

        public override void Dispose()
        {
            base.Dispose();
            logStream.Dispose();
        }
        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await logStream.DisposeAsync();
        }
    }
    public class CompanyConfigure : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {            
            builder.ToTable("Enterprises").Property(c => c.Name).IsRequired();            
            builder.HasData(
                new Company ("Microsoft") { Id = 1},
                new Company ("Google") { Id = 2},
                new Company ("Amazon") { Id = 3});
        }
    }
}
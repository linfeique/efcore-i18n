using I18N.Entities;
using Microsoft.EntityFrameworkCore;

namespace I18N.Infra;

public class Db : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public DbSet<Cinema> Cinemas { get; set; }

    public Db(DbContextOptions options) : base(options)
	{
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(e =>
        {
            e.HasKey(e => e.Id);

            e.HasOne(d => d.Cinema).WithMany(d => d.Movies).HasForeignKey(d => d.CinemaId);

            e.OwnsMany(d => d.Translations, op =>
            {
                op.ToJson();
            });
        });

        modelBuilder.Entity<Cinema>(e =>
        {
            e.HasKey(e => e.Id);

            e.HasMany(d => d.Movies).WithOne(d => d.Cinema).HasForeignKey(d => d.CinemaId);
        });

        base.OnModelCreating(modelBuilder);
    }
}

namespace WebApplication8.Data;

using WebApplication8.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<CapitolInvatare> Capitole { get; set; }
    public DbSet<IntrebariQuizz> Intrebari { get; set; }
    public DbSet<Utilizator> Utilizatori { get; set; }
    public DbSet<RezultatQuizz> Rezultate { get; set; }
    
    public DbSet<IstoricRezultate> Istorice { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the model

        modelBuilder.Entity<Todo>().ToTable("Todo");
        modelBuilder.Entity<Todo>().HasKey(t => t.Id);
        modelBuilder.Entity<Todo>().Property(t => t.Title).IsRequired();

        modelBuilder.Entity<CapitolInvatare>().ToTable("CapitolInvatare");
        modelBuilder.Entity<CapitolInvatare>().HasKey(t => t.CapitolInvatareId);
        modelBuilder.Entity<CapitolInvatare>().Property(t => t.Titlu);
        modelBuilder.Entity<CapitolInvatare>().Property(t => t.Continut);

        modelBuilder.Entity<IntrebariQuizz>().ToTable("IntrebariQuizz");
        modelBuilder.Entity<IntrebariQuizz>().HasKey(t => t.IntrebareId);
        modelBuilder.Entity<IntrebariQuizz>().Property(t => t.OptiuniRaspuns).IsRequired();
        modelBuilder.Entity<IntrebariQuizz>().Property(t => t.RaspunsCorect).IsRequired();
        modelBuilder.Entity<IntrebariQuizz>().Property(t => t.TextIntrebare).IsRequired();

        
        modelBuilder.Entity<RezultatQuizz>().ToTable("RezultatQuizz");
        modelBuilder.Entity<RezultatQuizz>().HasKey(t => t.RezultatQuizzId);
        modelBuilder.Entity<RezultatQuizz>().Property(t => t.IntrebareId).IsRequired();
        modelBuilder.Entity<RezultatQuizz>().Property(t => t.ScorObtinut).IsRequired();

        // Definirea cheii primare compuse
        modelBuilder.Entity<IstoricRezultate>()
            .HasKey(ir => new { ir.UtilizatorId, ir.RezultatQuizzId });


        modelBuilder.Entity<Utilizator>().ToTable("Utilizator");

        // Configureaza entitatea Utilizator
        modelBuilder.Entity<Utilizator>(entity =>
        {
            entity.HasKey(e => e.UtilizatorId);
            entity.Property(e => e.NumeUtilizator).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Parola).IsRequired();
            entity.HasIndex(e => e.Rol).IsUnique();
        });
        
        // Definirea relatiei intre Utilizator si IstoricRezultate
        modelBuilder.Entity<IstoricRezultate>()
            .HasOne(ir => ir.Utilizator);

        // Definirea relatiei intre RezultatQuizz si IstoricRezultate
        modelBuilder.Entity<IstoricRezultate>()
            .HasMany<RezultatQuizz>(rq => rq.RezultatQuizz);
    }
}
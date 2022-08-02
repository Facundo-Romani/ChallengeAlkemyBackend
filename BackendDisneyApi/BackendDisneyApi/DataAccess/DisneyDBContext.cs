using BackendDisneyAp.Models;
using BackendDisneyApi.Models;
using BackendDisneyApi.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BackendDisneyApi.DataAccess
{
    public class DisneyDBContext : DbContext
    {
        public DisneyDBContext(DbContextOptions<DisneyDBContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterMovie>().HasKey(a => new
            {
                a.MovieOrSerieId,
                a.CharacterId
            });

            modelBuilder.Entity<CharacterMovie>()
                .HasOne(x => x.MovieOrSerie)
                .WithMany(a => a.CharacterMovies)
                .HasForeignKey(c => c.MovieOrSerieId);

            modelBuilder.Entity<CharacterMovie>()
                .HasOne(x => x.Character)
                .WithMany(a => a.CharacterMovies)
                .HasForeignKey(c => c.CharacterId);

            base.OnModelCreating(modelBuilder);
        }


        // ADD DbSets (Tables DB).
        public DbSet<Character>? characters { get; set; }
        public DbSet<CharacterMovie> CharacterMovies { get; set; }
        public DbSet<Gender> Genders{ get; set; }
        public DbSet<MovieOrSerie> MoviesOrSeries { get; set; }

    }

}


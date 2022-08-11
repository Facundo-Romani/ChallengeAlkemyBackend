using BackendDisneyApi.Models;
using BackendDisneyApi.Services.Implements;
using BackendDisneyApi.Services;
using BackendDisneyApi.Base;
using BackendDisneyApi.ViewModels;
using System;
using BackendDisneyApi.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BackendDisneyApi.Repositories
{
    public class MovieRepository : EntityBaseRepository<MovieOrSerie>, IMovieRepository
    {
        private readonly DisneyDBContext _context;

        public MovieRepository(DisneyDBContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<MovieOrSerie> GetByName(string name)
        {
            var query = _context.MoviesOrSeries.Where(n => n.Name.Contains(name));

            return query;
        }

        public IQueryable<MovieOrSerie> MovieFilter(string genre)
        {
            var query = _context.MoviesOrSeries.Where(n => n.Name.Contains(genre));

            return query;
        }

        public async Task<MovieOrSerie> GetDetails(int id)
        {
            var currentMovie = await _context.MoviesOrSeries.FirstAsync(
            x => x.Id == id);

            return currentMovie;
        }

        public async Task<IEnumerable<GetMovieDetails>> GetAll()
        {
            var movieList = await _context.MoviesOrSeries.ToListAsync();

            var modelList = movieList.Select(a => new GetMovieDetails
            {
                Name = a.Name,
                Image = a.Image,
                CreatedAt = a.CreatedAt
            });

            return modelList;
        }

        public async Task CreateMovie(CreateMovie model)
        {
            var newMovie = new MovieOrSerie()
            {
                Name = model.Name,
                Image = model.Image,
                CreatedAt = model.CreatedAt,
                GenderId = model.GenreId,
                Calification = model.Calification,
            };

            await _context.MoviesOrSeries.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            foreach (var characterId in model.CharactersId)
            {
                var newCharMovie = new CharacterMovie()
                {
                    MovieOrSerieId = model.Id,
                    CharacterId = characterId
                };
                await _context.CharacterMovies.AddAsync(newCharMovie);
            }

            await _context.SaveChangesAsync();
        }
        public async Task UpdateMovie(UpdateMovie model)
        {
            var dbMovie = await _context.MoviesOrSeries.FirstOrDefaultAsync(n => n.Id == model.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = model.Name;
                dbMovie.Image = model.Image;
                dbMovie.CreatedAt = model.CreatedAt;
                dbMovie.GenderId = model.GenreId;
                dbMovie.Calification = model.Calification;

                await _context.SaveChangesAsync();
            }

            var existingCharactersDB = _context.CharacterMovies.Where(n => n.MovieOrSerieId == model.Id).ToList();
            _context.CharacterMovies.RemoveRange(existingCharactersDB);
            await _context.SaveChangesAsync();

            foreach (var characterId in model.CharactersId)
            {
                var newCharMovie = new CharacterMovie()
                {
                    MovieOrSerieId = model.Id,
                    CharacterId = characterId,
                };

                await _context.CharacterMovies.AddAsync(newCharMovie);
            }

            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            var entity = _context.MoviesOrSeries.Any(x => x.Id == id);

            if (entity)
            {
                return true;
            }

            return false;
        }
        public bool Exists(string name)
        {
            var character = _context.MoviesOrSeries.FirstOrDefault(a =>
                a.Name.ToLower().Contains(name.ToLower()));

            if (character == null)
            {
                return false;
            }

            return true;
        }


    }
}

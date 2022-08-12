using BackendDisneyApi.Models;
using BackendDisneyApi.Repositories;
using BackendDisneyApi.Services.Implements;
using BackendDisneyApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendDisneyApi.Services
{
    public class MovieService : EntityBaseService<MovieOrSerie>, IMovieService
    {
        private readonly IMovieRepository _repository;
        public MovieService(IMovieRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public IQueryable<MovieOrSerie> GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public async Task<MovieOrSerie> GetDetails(int id)
        {
            return await _repository.GetDetails(id);
        }

        public Task<IEnumerable<GetMovieDetails>> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<MovieOrSerie> MovieFilter(string genre)
        {
            var filtered = _repository.MovieFilter(genre);

            return filtered;
        }

        public Task CreateMovie(CreateMovie model)
        {
            return _repository.CreateMovie(model);
        }

        public Task UpdateMovie(UpdateMovie model)
        {
            return _repository.UpdateMovie(model);
        }
        public bool Exists(string name)
        {
            return _repository.Exists(name);
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }
    }
}

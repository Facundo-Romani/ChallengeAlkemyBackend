using BackendDisneyApi.Models;
using BackendDisneyApi.Repositories;
using BackendDisneyApi.Services.Implements;
using BackendDisneyApi.ViewModels;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BackendDisneyApi.Services
{
    public class CharacterService : EntityBaseService<Character>, ICharacterService
    {
        private readonly ICharacterRepository _repository;
        public CharacterService(ICharacterRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public IQueryable<Character> GetByName(string name)
        {
            if (!_repository.Exists(name))
            {
                throw new NullReferenceException("Character not found");
            }

            return _repository.GetByName(name);
        }

        public async Task<Character> GetDetails(int id)
        {
            return await _repository.GetDetails(id);
        }

        public Task<IEnumerable<GetCharList>> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Character> CharFilter(int age, float weight, int movieId)
        {
            var filtered = _repository.CharFilter(age, weight, movieId);

            return filtered;
        }

        public Task CreateChar(CreateChar model)
        {
            return _repository.CreateChar(model);
        }

        public Task UpdateChar(UpdateChar model)
        {
            return _repository.UpdateChar(model);
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

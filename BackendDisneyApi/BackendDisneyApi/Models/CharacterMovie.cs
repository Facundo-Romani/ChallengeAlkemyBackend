using System.ComponentModel.DataAnnotations;

namespace BackendDisneyApi.Models
{
    public class CharacterMovie
    {
        public int MovieOrSerieId { get; set; }
        public MovieOrSerie MovieOrSerie { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}

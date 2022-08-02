using BackendDisneyApi.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendDisneyApi.Models.DataModels
{
    public class Character : BaseEntity
    {
        public int? Age { get; set; }
        public int? Weight { get; set; }
        public string History { get; set; } = string.Empty;

        // Lista para generar la relación ForeignKey.
        public List<CharacterMovie> CharacterMovies { get; set; }
    }
}

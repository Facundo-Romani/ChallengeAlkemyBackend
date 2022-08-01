using BackendDisneyApi.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDisney.Models
{
    public class MovieOrSerie : BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Calification { get; set; }
        public List<CharacterMovie> CharacterMovies { get; set; }
    
        public int GenderId { get; set; }
        [ForeignKey("GenderId")]

        public Gender Gender { get; set; } = new Gender();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendDisneyApi.ViewModels
{
    public class UpdateMovie
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required, Range(1, 5)]
        public int Calification { get; set; }
        public List<int> CharactersId { get; set; } = new List<int>();
        public int GenreId { get; set; }
    }
}

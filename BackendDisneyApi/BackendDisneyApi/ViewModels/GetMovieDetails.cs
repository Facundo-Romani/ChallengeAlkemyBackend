using BackendDisneyApi.Models;
using System;
using System.Collections.Generic;

namespace BackendDisneyApi.ViewModels
{
    public class GetMovieDetails
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Calification { get; set; }
        public List<Character> Characters { get; set; } = new List<Character>();
        public Gender Gender { get; set; } = new Gender();
    }
}

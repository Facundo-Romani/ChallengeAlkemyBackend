using BackendDisneyApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendDisneyApi.ViewModels
{
    public class GetCharDetails
    {
        [Display(Name = "Character name")]
        public string Name { get; set; }

        [Display(Name = "URL Image")]
        public string Image { get; set; }

        [Display(Name = "Age")]
        public int? Age { get; set; }

        [Display(Name = "Weight in kg")]
        public int? Weight { get; set; }

        [Display(Name = "About character")]
        public string History { get; set; }

        [Display(Name = "Related movies")]
        public List<MovieOrSerie> MovieOrSerie { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendDisneyApi.ViewModels
{
    public class UpdateChar
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Name is required")]
        public int Id { get; set; }

        [Display(Name = "Character name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "URL Image")]
        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "Name is required")]
        public int? Age { get; set; }

        [Display(Name = "Weight in kg")]
        [Required(ErrorMessage = "Name is required")]
        public int? Weight { get; set; }

        [Display(Name = "About character")]
        [Required(ErrorMessage = "Name is required")]
        public string History { get; set; }

        [Display(Name = "Related movies")]
        [Required(ErrorMessage = "Name is required")]
        public List<int> IdMovieOrSerie { get; set; } = new List<int>();
    }
}

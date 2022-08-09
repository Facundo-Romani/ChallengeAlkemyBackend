using System.ComponentModel.DataAnnotations;

namespace BackendDisneyApi.ViewModels
{
    public class GetCharList
    {
        [Display(Name = "Character name")]
        public string Name { get; set; }

        [Display(Name = "URL Image")]
        public string Image { get; set; }
    }
}

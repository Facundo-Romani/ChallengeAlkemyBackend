using System.ComponentModel.DataAnnotations;

namespace BackendDisneyApi.Models.DataModels
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty; 
    }
}

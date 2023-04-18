using System.ComponentModel.DataAnnotations;

namespace SerkanBilselGorev7.Models
{
    public class Slider
    {
        public int Id { get; set; }

        [Display(Name = "Resim"), StringLength(50)]
        public string? Image { get; set; }
    }

}

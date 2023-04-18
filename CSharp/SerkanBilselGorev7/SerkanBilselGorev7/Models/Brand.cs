using System.ComponentModel.DataAnnotations;

namespace SerkanBilselGorev7.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Display(Name = "Marka Adı"), StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Marka Açıklaması")]
        public string? Desciption { get; set; }

        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        public string? Logo { get; set; }

        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SerkanBilselGorev7.Models

{
    public class Categories
    {
        public int Id { get; set; }
        [Display(Name = "Adı"), StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Kategori Açıklaması"),]
        public string? Description { get; set; }

        [Display(Name = "Eklenme Tarihi")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}      

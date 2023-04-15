using Microsoft.CodeAnalysis.FindSymbols;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SerkanBilselGorev7.Models
{
    public class Products
    {
        public int Id { get; set; }
      
        [Display(Name = "Ürün Adı"), StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Kategori")]
        public string? Categories { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        [Display(Name = "Fiyat")]
        public double? Price { get; set; }

        public string? Status { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Display(Name = "Stok Adedi")]
        public int? Stock { get; set; }
        [Display(Name = "Resim"), StringLength(50)]
        public string? Image { get;  set; }
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        [Display(Name = "Kategori")]
        public Categories? Category { get; set; }
    }
}

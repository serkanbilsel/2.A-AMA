using Microsoft.CodeAnalysis.FindSymbols;
using System.ComponentModel.DataAnnotations;

namespace SerkanBilselGorev7.Models
{
    public class Products
    {
        public int Id { get; set; }


        [Display(Name = "Ürün Adı"), StringLength(50)]
        public string Name { get; set; }


        [Display(Name = "Ürün Açıklaması")]
        public string? Description { get; set; }


        [Display(Name = "Fiyat")]
        public decimal? Price { get; set; }


        [Display(Name = "Stok")]
        public int Stock { get; set; }


        [Display(Name = "Resim")]
        public string? Image { get; set; }


        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;


        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }


        [Display(Name = "Kategori")]
        public Categories? Category { get; set; }


    }
}

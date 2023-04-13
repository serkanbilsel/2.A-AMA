using System.ComponentModel.DataAnnotations;

namespace P013WebSite.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Ürün Adı"), StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        [Display(Name = "Fiyat")]
        public decimal? Price { get; set; }
        [Display(Name = "Stok Adedi")]
        public int Stock { get; set;}
        [Display(Name = "Resim"), StringLength(50)]
        public string? Image { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)] // ScaffoldColumn Oluşacak View'larda  CreateDate alanının otomatik oluşturulmasını engeller
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; } // CategoryId DB deki Foreign Key olacak.
        [Display(Name = "Kategori")]
        public Category? Category { get; set; } // ürün ile kategori class'ını bir e bir ilişki ile bağladık


    }
}

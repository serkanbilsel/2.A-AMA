using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace P013WebSite.Entities
{
    public class Category
    {
        // Katmanlı Mimari için Entities gibi varlıklarım dosyası oluşturduk

        public int Id { get; set; }

        [Display(Name = "Kategori Adı"), StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Kategori Açıklaması")]
        public string? Description { get; set; }

        [Display(Name = "Eklenme Tarihi"),ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now; // Sonradan bir class'a bu şekilde property eklersek yeni bir migration eklememiz gerekir! Aksi takdirde hata alırız.


    }
}

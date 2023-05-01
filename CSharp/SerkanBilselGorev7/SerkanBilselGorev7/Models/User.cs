using System.ComponentModel.DataAnnotations;

namespace SerkanBilselGorev7.Models
{
    public class User
    {

        public int Id { get; set; }
        [Display(Name = "Ad"), StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "SoyAd"), StringLength(50)]
        public string? LastName { get; set; }
        [Display(Name = "Mail"), StringLength(50)]
        public string Email { get; set; }
        [Display(Name = "Şifre"), StringLength(50)]
        public string Password { get; set; }
        [Display(Name = "Durum"), StringLength(50)]

        public bool IsActive { get; set; }
        [Display(Name = "Admin"), StringLength(50)]
        public bool IsAdmin{ get; set; }

        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;



    }
}

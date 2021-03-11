using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [Display(Name ="Kullanıcı Adı"), StringLength(50), Required]
        public string UserName { get; set; }
        [Display(Name = "Şifre"), StringLength(100), Required]
        public string Password { get; set; }
        [StringLength(50), Required]
        public string Email { get; set; }
        [Display(Name = "Adı"), StringLength(50), Required]
        public string Name { get; set; }
        [Display(Name = "Soyadı"), StringLength(50)]
        public string SurName { get; set; }
        [Display(Name = "Telefon"), StringLength(15)]
        public string Phone { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
    }
}

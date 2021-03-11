using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Üst Kategorisi")]
        public int? ParentId { get; set; } = 0;//Varsayılan değer 0
        [Display(Name = "Kategori Adı"), StringLength(50), Required]
        public string Name { get; set; }
        [Display(Name = "Aktif/Pasif")]
        public bool IsActive { get; set; }
        [Display(Name = "Anasayfa")]
        public bool IsHomePage { get; set; }
        [Display(Name = "Kategori Resmi"), StringLength(100), DataType(DataType.ImageUrl)]
        public string CategoryImg { get; set; }
        [Display(Name = "Kategori Arkaplan Resmi"), StringLength(100), DataType(DataType.ImageUrl)]
        public string BackGroundImg { get; set; }
        [Display(Name = "Kategori İçeriği"), DataType(DataType.MultilineText)]
        public string CategoryContent { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Content : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "İçerik Kategorisi"), Required]
        public int CategoryId { get; set; }
        [Display(Name = "İçerik Adı"), StringLength(50), Required]
        public string Name { get; set; }
        [Display(Name = "Aktif/Pasif")]
        public bool IsActive { get; set; }
        [Display(Name = "İçerik Resmi"), StringLength(100)]
        public string ContentImg { get; set; }
        [Display(Name = "Kısa Açıklama"), StringLength(100)]
        public string Description { get; set; }
        [Display(Name = "İçerik Detay"), DataType(DataType.MultilineText)]
        public string Detail { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual Category Category { get; set; }
    }
}

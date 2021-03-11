using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Slide : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Slide Resmi"), StringLength(100)]
        public string SlideImg { get; set; }
    }
}

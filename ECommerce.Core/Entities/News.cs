using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Entities
{
    public class News : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }

        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]

        public DateTime CreateDate { get; set; } =DateTime.Now;


        public Language Language { get; set; }

        public int LanguageId { get; set; } = 7;
    }
}

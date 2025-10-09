using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Entities
{
    public  class Brand : IEntity
    {

        public int Id { get; set; }

        [Display(Name = "Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklaması")]
        public string? Description { get; set; }

        public string?  Logo { get; set; }


        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }

        [Display(Name = "Sıra Numarası")]
        public int OrderNo { get; set; }


        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public IList<Product>? Products { get; set; }

        public Language Language { get; set; }

        public int LanguageId { get; set; } = 7;

    }
}

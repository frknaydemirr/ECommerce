using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı")]
        public string Name { get; set; }

        [Display(Name = "Açıklaması")]
        public string? Description { get; set; }


        [Display(Name = "Resim")]
        public string? Image { get; set; }

        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }

        [Display(Name = "Üst Menüde Göster ? ")]
        public bool IsTopMenu { get; set; }

        [Display(Name = "Üst Kategori")]
        public int ParentId { get; set; }

        [Display(Name = "Sıra Numarası")]
        public int OrderNo { get; set; }

        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }

        public IList<Product>? Products { get; set; }
        //one category includes many products


        public Language Language { get; set; }

        public int LanguageId { get; set; } = 7;

    }
}

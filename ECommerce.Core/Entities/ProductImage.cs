using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Entities
{
    public class ProductImage : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Resim Adı"),StringLength(240)]
        public string? Name { get; set; }
        [Display(Name = "Resim Açıklama (Alt Tagı)"), StringLength(500)]

        public string? Alt { get; set; }
        [Display(Name = "Ürün")]

        public int? ProductId { get; set; }
        [Display(Name = "Ürün")]
        public Product? Product { get; set; }


        public Language Language { get; set; }

        public int LanguageId { get; set; } = 7;



    }
}

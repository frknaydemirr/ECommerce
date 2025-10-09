using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Entities
{
    public class OrderLine : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Sipariş No")]

        public int OrderId { get; set; }

        [Display(Name = "Sipariş")]

        public Order? Order { get; set; }

        [Display(Name = "Ürün No")]

        public int ProductId { get; set; }

        [Display(Name = "Ürün")]


        public Product?   Product { get; set; }

        [Display(Name = "Miktar")]


        public int Quantity { get; set; }

        [Display(Name = "Birim Fİyatı")]


        public Language Language { get; set; }

        public int LanguageId { get; set; } = 7;

        public decimal UnitPrice { get; set; }
    }
}



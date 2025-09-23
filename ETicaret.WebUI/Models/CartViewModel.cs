using ECommerce.Core.Entities;

namespace ETicaret.WebUI.Models
{
    public class CartViewModel
    {
        public List<CartLine>?  cartLines { get; set; }

        public decimal  TotalPrice { get; set; }
    }
}

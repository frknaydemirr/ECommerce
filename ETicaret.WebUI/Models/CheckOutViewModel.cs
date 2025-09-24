using ECommerce.Core.Entities;

namespace ETicaret.WebUI.Models
{
    public class CheckOutViewModel
    {
        public List<CartLine>? CartProducts { get; set; }

        public decimal TotalPrice { get; set; }

        public List<Address>? Addresses { get; set; }




    }
}

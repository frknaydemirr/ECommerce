using ECommerce.Core.Entities;
using ECommerce.Service.Abstract;

namespace ECommerce.Service.Concrete
{
    public class CartService : ICartService
    {
        public List<CartLine> CartLines = new();
        public void AddProduct(Product product, int quantity)
        {
            var urun = CartLines.FirstOrDefault(x => x.Product.Id == product.Id);
            if(urun != null)
            {
                urun.Quantity += quantity;
            }
            else
            {
                CartLines.Add(new CartLine { Product = product, Quantity = quantity });
            }
        }

        public void ClearAll()
        {
           CartLines.Clear();
        }

        public void RemoveProduct(Product product)
        {
           CartLines.RemoveAll(x => x.Product.Id == product.Id);
        }

        public decimal TotalPrice()
        {
          return  CartLines.Sum(x => x.Product.Price * x.Quantity);
        }

        public void UpdateProduct(Product product, int quantity)
        {
            var urun = CartLines.FirstOrDefault(x => x.Product.Id == product.Id);
            if (urun != null)
            {
                urun.Quantity = quantity;
            }
            else
            {
                CartLines.Add(new CartLine { Product = product, Quantity = quantity });
            }
        }
    }
}

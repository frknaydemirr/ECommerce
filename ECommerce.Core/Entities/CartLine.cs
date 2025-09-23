namespace ECommerce.Core.Entities
{
    public  class CartLine
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public Product  Product { get; set; }

        public int Quantity { get; set; }
    }
}

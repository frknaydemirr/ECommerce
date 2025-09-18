namespace ECommerce.Core.Entities
{
    public  class Brand : IEntity
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string?  Logo { get; set; }

        public bool IsActive { get; set; }
    }
}
a
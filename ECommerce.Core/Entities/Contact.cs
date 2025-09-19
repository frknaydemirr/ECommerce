namespace ECommerce.Core.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }


        public string Message { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}

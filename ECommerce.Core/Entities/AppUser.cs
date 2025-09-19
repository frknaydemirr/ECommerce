namespace ECommerce.Core.Entities
{
    public class AppUser : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string SurName { get; set; }


        public string Email { get; set; }


        public string? Phone { get; set; }

        public string Password { get; set; }

        public string? UserName { get; set; }

        public bool isActive { get; set; }

        public bool isAdmin { get; set; }

        public DateTime CreateDate { get; set; }=DateTime.Now;

        public Guid? UserGuid { get; set; } = Guid.NewGuid();
    }
}

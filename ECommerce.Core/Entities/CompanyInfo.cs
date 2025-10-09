namespace ECommerce.Core.Entities
{
    public class CompanyInfo : IEntity
    {
         public int Id { get; set; }

        public string  Address { get; set; }

        public string  Email { get; set; }


        public string PhoneNumber { get; set; }

        public string? InstagramURL { get; set; }

        public string? FacebookURL { get; set; }

        public string? TwitterURL { get; set; }


        public Language Language { get; set; }

        public int LanguageId { get; set; } = 7;

    }
}

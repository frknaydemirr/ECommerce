
namespace ECommerce.Core.Entities
{
    public class Resource : IEntity
    {
        public int Id { get; set; }

        public  string  Value { get; set; }

        public string Page { get; set; }


        public string NavigationName { get; set; }

        public Language Language { get; set; }

        public int LanguageId { get; set; } = 7;


    }
}

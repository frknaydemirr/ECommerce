
namespace ECommerce.Core.Entities
{
    public class Language : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Icon { get; set; }


        public string ShortTitle { get; set; }

        public bool Active { get; set; }


    }
}

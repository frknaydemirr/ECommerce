

namespace ECommerce.Core.Entities
{
    public class NavbarMain : IEntity
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string URL { get; set; }

        public bool isActive { get; set; } = true;

        public bool isMainMenu { get; set; }

        public bool isTopMenu { get; set; }

        public int LanguageId { get; set; } = 7;


        public Language Language { get; set; }


        public int Turn { get; set; } = 1;


        public string MetaTitle { get; set; } = string.Empty;


        public string MetaDescription { get; set; } = string.Empty;

        public string MetaKeywords { get; set; } = string.Empty;

        public string SeoURL { get; set; } = string.Empty;
    }
}

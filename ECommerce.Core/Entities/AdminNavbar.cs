

namespace ECommerce.Core.Entities
{
    public class AdminNavbar : IEntity
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string URL { get; set; }

        public bool isActive { get; set; } = true;


        public int LanguageId { get; set; } = 7;


        public Language Language { get; set; }


        public int Turn { get; set; }


    }


}

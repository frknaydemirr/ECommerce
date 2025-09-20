using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Adı")]
        public string Name { get; set; }

        [Display(Name = "Soady")]
        public string Surname { get; set; }

        public string? Email { get; set; }

        [Display(Name = "Telefon Numarası")]
        public string? Phone { get; set; }

        [Display(Name = "Mesaj")]
        public string Message { get; set; }

        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]

        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}

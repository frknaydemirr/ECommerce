using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Entities
{
    public  class Address :IEntity
    {
        public int Id { get; set; }
        [Display(Name ="Adres Başlığı"), StringLength(50),Required(ErrorMessage = "{0} Alanı Zorunludur!")]


        public string Title { get; set; }
        [Display(Name = "Şehir"),StringLength(50), Required(ErrorMessage = "{0} Alanı Zorunludur!")]


        public string City { get; set; }
        [Display(Name = "İlçe"), StringLength(50), Required(ErrorMessage = "{0} Alanı Zorunludur!")]
        public string District { get; set; }
        [Display(Name = "Açık Adres"),DataType(DataType.MultilineText), Required(ErrorMessage = "{0} Alanı Zorunludur!")]


        public string OpenAdress { get; set; }
        [Display(Name = "Aktif")]

        public bool isBilllingAdress { get; set; }
        [Display(Name = "Fatura Adresi")]

        public bool isDeliveryAdress { get; set; }
        [Display(Name = "Kayıt Tarihi "),ScaffoldColumn(false)]


        public DateTime CreateDate { get; set; } = DateTime.Now;
        [ScaffoldColumn(false)]
        public Guid AdressGuid { get; set; } = Guid.NewGuid();

        public int? AppUserId { get; set; }

        public AppUser? AppUser { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; } = true;

        public Language Language { get; set; }

        public int LanguageId { get; set; } = 7;


    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        [Display(Name = "Fiyat")]
        public Decimal Price { get; set; }
        [Display(Name = "Ürün Kodu")]
        public string? ProductCode { get; set; }
        [Display(Name = "Stok")]
        public int Stock { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
        [Display(Name = "Anasayfa  ? ")]
        public bool IsHome { get; set; }

        [Display(Name = "Kategori")]
        public int? CategoryId { get; set; }
        [Display(Name = "Adı")]
        public Category?  Category { get; set; }
        [Display(Name = "Kategori")]
        public int? BrandId { get; set; }

        [Display(Name = "Marka")]
        public Brand? Brand { get; set; }
        [Display(Name = "Sıra")]
        public int? OrderNo { get; set; }

        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}

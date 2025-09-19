namespace ECommerce.Core.Entities
{
    public class Slider : IEntity
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public string? Link { get; set; }

    }
}

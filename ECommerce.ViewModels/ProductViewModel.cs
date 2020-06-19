using System;

namespace ECommerce.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ThumbnailUrl { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
    }
    
}

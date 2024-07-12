

namespace Application.DTOs.Product
{
    public class UpdateProductRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string? Cover_Img { get; set; }
        public int? CategoryId { get; set; }
    }
}

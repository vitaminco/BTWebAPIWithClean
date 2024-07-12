

namespace Domain.Entities
{
    public class AppProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string? Cover_Img { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        //1 sản phẩm thuộc 1 danh mục
        public AppCategory Category { get; set; }
        
    }
}

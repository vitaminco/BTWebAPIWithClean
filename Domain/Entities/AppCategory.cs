

namespace Domain.Entities
{
    public class AppCategory
    {
        public AppCategory()
        {
            products = new HashSet<AppProduct>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Img { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get;set; }
        //1 danh mục có nhiều sản phẩm
        public ICollection<AppProduct> products { get; set; }
    }
}

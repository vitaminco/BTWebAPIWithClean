

using System.Text.Json.Serialization;

namespace Application.DTOs.Category
{
    public class CreateCategoryRequest
    {
        [JsonRequired]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Img { get; set; }
    }
   
}

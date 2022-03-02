using System.Text.Json.Serialization;

namespace SimpleBookApi.Dtos
{
    public class EditBookDto : BookDto
    {
        public EditBookDto(string? name, string? author, DateTime? registration, string? category, string? description) : base(name, author, registration, category, description)
        {
        }
        
        [JsonInclude]
        public override int Id { get; set; }

    }
}

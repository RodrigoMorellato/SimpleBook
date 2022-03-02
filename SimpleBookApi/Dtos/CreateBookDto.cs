using System.Text.Json.Serialization;

namespace SimpleBookApi.Dtos
{
    public class CreateBookDto : BookDto
    {
        public CreateBookDto(string? name, string? author, DateTime? registration, string? category, string? description) : base(name, author, registration, category, description)
        {
        }

        [JsonIgnore]
        public override int Id { get; set; }
    }
}

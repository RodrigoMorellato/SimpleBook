using System.Text.Json.Serialization;

namespace SimpleBookWebApp.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            
        }
        public BookViewModel(string? name, string? author, DateTime? registration, string? category, string? description)
        {
            Name = name;
            Author = author;
            Registration = registration;
            Category = category;
            Description = description;
        }

        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public DateTime? Registration { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
    }
}

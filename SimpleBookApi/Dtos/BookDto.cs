using SimpleBookApi.Swagger;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SimpleBookApi.Dtos
{
    public abstract class BookDto
    {
        protected BookDto(string? name, string? author, DateTime? registration, string? category, string? description)
        {
            Name = name;
            Author = author;
            Registration = registration;
            Category = category;
            Description = description;
        }

        [JsonIgnore]
        public virtual int Id { get; set; }

        [SwaggerSchema("Book name.")]
        [StringLength(50)]
        [SwaggerSchemaExample("Sky")]
        public string? Name { get; set; }

        [SwaggerSchema("Author name.")]
        [StringLength(50)]
        [SwaggerSchemaExample("Barnabeu")]
        public string? Author { get; set; }

        [SwaggerSchema("Book resgistration.")]
        [SwaggerSchemaExample("2022-03-01")]
        public DateTime? Registration { get; set; }

        [SwaggerSchema("Book category.")]
        [SwaggerSchemaExample("Drama")]
        public string? Category { get; set; }

        [SwaggerSchema("Book description.")]
        [StringLength(50)]
        [SwaggerSchemaExample("Story about the blues sky into 50 years.")]
        public string? Description { get; set; }
    }
}

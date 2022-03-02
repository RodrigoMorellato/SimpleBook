using System.ComponentModel.DataAnnotations;

namespace SimpleBookApi.Models
{
    public abstract class BaseClass
    {
        [Key]
        public int Id { get; set; }
    }
}

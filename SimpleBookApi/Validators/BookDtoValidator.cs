using FluentValidation;
using SimpleBookApi.Dtos;
using SimpleBookApi.Enums;

namespace SimpleBookApi.Validators
{
    public class BookDtoValidator : AbstractValidator<BookDto>
    {
        public BookDtoValidator()
        {
            RuleFor(b => b.Author).NotEmpty();
            RuleFor(b => b.Author).NotEmpty();
            RuleFor(b => b.Registration).NotEmpty();
            RuleFor(b => b.Category).NotEmpty().IsEnumName(typeof(EnumCategory));
            RuleFor(b => b.Description).NotEmpty();
        }
    }
}

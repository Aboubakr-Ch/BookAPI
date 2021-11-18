using BookAPI.Models;
using FluentValidation;

namespace BookAPI.Validator
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(model => model.Author).NotEmpty();
        }
    }
}

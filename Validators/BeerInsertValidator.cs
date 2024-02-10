using Api.DTOs;
using FluentValidation;

namespace Api.Validators
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDto>
    {

        public BeerInsertValidator() {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Alcohol).NotEmpty().WithMessage("{PropertyName}No puede ser null or empty");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("Entre 2 y 20 caracteres");

        }
    }
}

using FluentValidation;
using CarGallery.Application.Cars.Dtos;
public class CreateCarValidator : AbstractValidator<CreateCarDto>
{
    public CreateCarValidator()
    {
        RuleFor(x => x.Brand).NotEmpty();
        RuleFor(x => x.Price).GreaterThan(0);
    }
}
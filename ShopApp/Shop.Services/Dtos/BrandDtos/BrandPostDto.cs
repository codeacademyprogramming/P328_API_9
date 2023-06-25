using FluentValidation;

namespace Shop.Services.Dtos.BrandDtos
{
    public class BrandPostDto
    {
        public string Name { get; set; }
    }

    public class BrandPostDtoValidator : AbstractValidator<BrandPostDto>
    {
        public BrandPostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
        }
    }
}

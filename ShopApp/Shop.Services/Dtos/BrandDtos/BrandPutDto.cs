using FluentValidation;

namespace Shop.Services.Dtos.BrandDtos
{
    public class BrandPutDto
    {
        public string Name { get; set; }
    }

    public class BrandPutDtoValidator : AbstractValidator<BrandPutDto>
    {
        public BrandPutDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
        }
    }
}

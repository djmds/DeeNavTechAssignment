using FluentValidation;

namespace NavTech.Configuration.API.Models
{
    public class ConfigurationInputModel
    {
        public string EntityType { get; set; }
    }

    public class ConfigurationInputModelValidator : AbstractValidator<ConfigurationInputModel>
    {
        public ConfigurationInputModelValidator()
        {
            RuleFor(a => a.EntityType).NotEmpty().WithMessage("EntityType is required.");
        }
    }
}

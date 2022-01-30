using FluentValidation;
using System.Collections.Generic;

namespace NavTech.Configuration.Models.ResponseModels
{

    public class EntityConfigurationModel
    {
        public List<EntityModel> Entities { get; set; }
    }

    public class EntityModel
    {
        public string EntityName { get; set; }
        public List<FieldModel> Fields { get; set; }
    }

    public class FieldModel
    {
        public string Field { get; set; }
        public bool IsRquired { get; set; }
        public int MaxLength { get; set; }
        public string Source { get; set; }
    }

    public class EntityModelValidator : AbstractValidator<EntityModel>
    {
        public EntityModelValidator(FieldModelValidator validator)
        {
            RuleFor(a => a.EntityName).NotEmpty().WithMessage("EntityName is required.");
            RuleFor(a => a.Fields).NotEmpty().WithMessage("Fields is required.");
            RuleForEach(a => a.Fields).SetValidator(validator);
        }
    }

    public class FieldModelValidator : AbstractValidator<FieldModel>
    {
        public FieldModelValidator()
        {
            RuleFor(a => a.Field).NotEmpty().WithMessage("Field is required.");
            RuleFor(a => a.Source).NotEmpty().WithMessage("Source is required.");
            RuleFor(a => a.IsRquired).NotEmpty().WithMessage("IsRquired is required.");
            RuleFor(a => a.MaxLength).NotEmpty().WithMessage("MaxLength is required.");
        }
    }

}

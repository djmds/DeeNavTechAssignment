using AutoMapper;
using NavTech.Configuration.DataAccess.Models;
using NavTech.Configuration.Models.ResponseModels;

namespace NavTech.Configuration.Models
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<EntityConfiguration, FieldModel>()
                .ForMember(a => a.Field, opt => opt.MapFrom(x => x.FieldName))
                .ForMember(a => a.IsRquired, opt => opt.MapFrom(x => x.IsRequired))
                .ForMember(a => a.MaxLength, opt => opt.MapFrom(x => x.MaxLength))
                .ForMember(a => a.Source, opt => opt.MapFrom(x => x.FieldSource));

            CreateMap<FieldModel, EntityConfiguration>()
                .ForMember(a => a.FieldName, opt => opt.MapFrom(x => x.Field))
                .ForMember(a => a.IsRequired, opt => opt.MapFrom(x => x.IsRquired))
                .ForMember(a => a.MaxLength, opt => opt.MapFrom(x => x.MaxLength))
                .ForMember(a => a.FieldSource, opt => opt.MapFrom(x => x.Source))
                .ForMember(a => a.EntityName, opt => opt.Ignore());
        }
    }
}

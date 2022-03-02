using AutoMapper;
using SimpleBookApi.Dtos;
using SimpleBookApi.Models;

namespace SimpleBookApi.AutoMapper
{
    public sealed class ViewModelsToModelsMappingProfile : Profile
    {
        public ViewModelsToModelsMappingProfile()
        {
            CreateMap<BookDto, Book>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForAllMembers(mo => mo.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

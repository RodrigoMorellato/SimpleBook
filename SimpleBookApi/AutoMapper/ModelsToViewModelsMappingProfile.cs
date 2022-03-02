using AutoMapper;
using SimpleBookApi.Dtos;
using SimpleBookApi.Models;

namespace SimpleBookApi.AutoMapper
{
    internal sealed class ModelsToViewModelsMappingProfile : Profile
    {
        public ModelsToViewModelsMappingProfile()
        {
            CreateMap<Book, CreateBookDto>();
            CreateMap<Book, EditBookDto>();
        }
    }
}

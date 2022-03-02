using AutoMapper;

namespace SimpleBookApi.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void ResgiterMappings()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ViewModelsToModelsMappingProfile>();
                cfg.AddProfile<ModelsToViewModelsMappingProfile>();
            });
        }
    }
}
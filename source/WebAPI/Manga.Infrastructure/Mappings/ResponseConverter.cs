namespace Manga.Infrastructure.Mappings
{
    using Manga.Application;
    using AutoMapper;

    public class ResponseConverter : IResponseConverter
    {
        private readonly IMapper mapper;

        public ResponseConverter()
        {
            mapper = new MapperConfiguration(cfg => {
                cfg.AddProfile<AccountsProfile>();
                cfg.AddProfile<CustomersProfile>();
            }).CreateMapper();
        }

        public T Map<T>(object source)
        {
            T model = mapper.Map<T>(source);
            return model;
        }
    }
}

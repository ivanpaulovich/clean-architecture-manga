namespace Acerola.Infrastructure.Mappings
{
    using Acerola.Application.Mappers;
    using AutoMapper;

    public class DTOMapper : IDTOMapper
    {
        private readonly IMapper mapper;

        public DTOMapper()
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

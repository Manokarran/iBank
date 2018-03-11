using AutoMapper;

namespace iBankApp.API.Automapper
{
    public class AutoMapperConfiguration
    {
        private static MapperConfiguration _mapperConfiguration;

        public AutoMapperConfiguration()
        {
            var mapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile<DomainToDTOProfile>(); });

            _mapperConfiguration = mapperConfig;
        }

        public IMapper CreateMapper()
        {
            return _mapperConfiguration.CreateMapper();
        }
    }
}
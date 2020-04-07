using AutoMapper;

namespace Task3.Api.Mapper
{
    public class TaskMapper
    {
        public IMapper Mapper { get; }

        public TaskMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ToEntityMapper());
            });

            this.Mapper = config.CreateMapper();
        }
    }
}

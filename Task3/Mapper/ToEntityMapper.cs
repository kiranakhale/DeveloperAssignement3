using AutoMapper;
using Task3.Common.Model;
using Task3.Repositories.Entities;

namespace Task3.Mapper
{
    public class ToEntityMapper : Profile
    {
        public ToEntityMapper()
        {
            CreateMap<TrainingModel, TrainingEntity>();
                
        }
    }
}

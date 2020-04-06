using AutoMapper;
using Task3.Common.Model;
using Task3.Repositories.Entities;

namespace Task3.Mapper
{
    public class ToEntityMapper : Profile
    {
        public ToEntityMapper()
        {
            CreateMap<CustomerModel, Customer>()
                .ForMember(x=>x.CustomerName,y=>y.MapFrom(src=>src.Name))
                .ReverseMap();
        }
    }
}

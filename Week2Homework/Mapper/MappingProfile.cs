using AutoMapper;
using Week2Homework.DataModel;

namespace Week2Homework.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO,Customer >();
        }

    }
}

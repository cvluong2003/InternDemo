using API.DTOs;
using AutoMapper;
using Data.EntityModel;

namespace API.Mapping
{
    public class MonhocConFig
    {
        public static void CreateMap(IMapperConfigurationExpression ex)
        {
            ex.CreateMap<SINHVIEN,SinhVien>().ReverseMap();
        }
    }
}

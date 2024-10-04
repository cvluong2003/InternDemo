using API.DTOs;
using AutoMapper;
using Data;
using Data.EntityModel;
namespace API.Mapping
{
    public class SinhVienConfig
    {
        public static void CreateMap(IMapperConfigurationExpression ex)
        {
            ex.CreateMap<SINHVIEN, SinhVien>().ForMember(dest=>dest.namSinh,opt=>opt.MapFrom(src=>src.NAMSINH));
        }
    }
}

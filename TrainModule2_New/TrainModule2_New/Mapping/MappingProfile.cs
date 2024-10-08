using AutoMapper;
using Data;
using Data.EntityModels;

using TrainModule2_New.DTOs;

namespace TrainModule2_New.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Sinhvien, SinhVienDTO>().ForMember(src=>src.namsinh,opt=>opt.MapFrom(src=>src.Namsinh.HasValue ? src.Namsinh.Value.Year : (int?)null));
            CreateMap<SinhVienDTO, Sinhvien>().ForMember(src=> src.Namsinh, opt => opt.MapFrom(src => src.namsinh.HasValue ? new DateOnly(src.namsinh.Value, 1, 1) : (DateOnly?)null));
            CreateMap<Lop, LopDTO>().ReverseMap();
            CreateMap<Monhoc,MonHocDTO>().ReverseMap();
            CreateMap<Ketqua, KetQuaDTO>().ReverseMap();
            CreateMap<Giaovien, GiaoVienDTO>().ReverseMap();
        }
    }
}

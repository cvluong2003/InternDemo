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
            
            CreateMap<Sinhvien, SinhVienDTO>().ForMember(des=>des.namsinh,opt=>opt.MapFrom(src=>src.Namsinh.HasValue? src.Namsinh.Value.Year.ToString() : string.Empty));
            CreateMap<SinhVienDTO, Sinhvien>().ForMember(des=> des.Namsinh, opt => opt.MapFrom(src => src.namsinh.Contains('-')? DateOnly.ParseExact(src.namsinh, "yyyy-MM-dd") : (DateOnly?)null));
            CreateMap<Lop, LopDTO>().ReverseMap();
            CreateMap<Monhoc,MonHocDTO>().ReverseMap();
            CreateMap<Ketqua, KetQuaDTO>().ReverseMap();
            CreateMap<Giaovien, GiaoVienDTO>().ReverseMap();
        }
    }
}

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
            
            CreateMap<Sinhvien, SinhVienDTO>().ForMember(des=>des.namsinh,opt=>opt.MapFrom( src=>src.Namsinh.Value.Year.ToString())).
                                                ForMember(des => des.ngaysinh, opt => opt.MapFrom(src => src.Namsinh.Value.ToString("dd-MM-yyyy")));
            CreateMap<SinhVienDTO, Sinhvien>().ForMember(des => des.Namsinh, opt => opt.MapFrom(src => DateOnly.ParseExact(src.ngaysinh, "dd-MM-yyyy")));
            CreateMap<Lop, LopDTO>().ReverseMap();
            CreateMap<Monhoc,MonHocDTO>().ReverseMap();
            CreateMap<Ketqua, KetQuaDTO>().ReverseMap();
            CreateMap<Giaovien, GiaoVienDTO>().ReverseMap();
        }
    }
}

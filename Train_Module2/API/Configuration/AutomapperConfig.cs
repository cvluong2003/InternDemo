using System.Runtime.CompilerServices;
using AutoMapper;
using Data;
using API.DTOs;
using Data.EntityModel;
namespace API.Configuration
{
    public class AutomapperConfig:Profile
    {
       public AutomapperConfig()
        {
            CreateMap<SINHVIEN, SinhVien>();
        }
    }
}

using API.DTOs;
using API.EntityModel;
using AutoMapper;
using Data.EntityModel;
namespace API.Mapping
{
    public class KetquaConfig
    {
        public static void CreateMap(IMapperConfigurationExpression ex)
        {
            ex.CreateMap<KETQUA, KetQua>().ReverseMap();
        }
    }
}

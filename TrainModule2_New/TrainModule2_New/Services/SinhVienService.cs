using Microsoft.EntityFrameworkCore;
using TrainModule2_New.DTOs;
using FluentValidation;
using TrainModule2_New.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.JsonPatch;
//using System.ComponentModel.DataAnnotations;
namespace TrainModule2_New.Services
{
    public interface ISinhVienService
    {
        Task<List<SinhVienDTO>> getallSinhVien();
        Task<SinhVienDTO> getSinhVienByID(int id);
        Task<SinhVienDTO> createSinhVien(SinhVienDTO sv);
        ValidationResult CheckSaveSinhVien(SinhVienDTO sv);
        Task<List<SinhVienDTO>> getSinhVienByClassCode(string classcode);
        Task<string> PutSinhVienByID(string id, SinhVienDTO sv);
        Task<bool> deleteSinhVienByID(int id);
        Task<bool> patchSinhVienByID(int id, JsonPatchDocument<SinhVienDTO> jdoc);
    }
    public class SinhVienService:ISinhVienService
    {
        public readonly ISinhVienModel _model;
        public readonly IValidator<SinhVienDTO> _validator;
        public SinhVienService(ISinhVienModel model,IValidator<SinhVienDTO> validator) {
            _model = model;
            _validator = validator;
        }
        public async Task<List<SinhVienDTO>> getallSinhVien()
        {
            return await _model.getall();
        }
        public async Task<SinhVienDTO> getSinhVienByID(int id)
        {
            return await _model.getSinhVienByID(id);
        }
        public async Task<SinhVienDTO> createSinhVien(SinhVienDTO sv)
        {
           
            return await _model.CreateSinhVien(sv);
        }
        public ValidationResult CheckSaveSinhVien(SinhVienDTO sv)
        {
            return _validator.Validate(sv);
        }
        public async Task<List<SinhVienDTO>> getSinhVienByClassCode(string classcode)
        {
            return await _model.GetSinhVienByClassCode(classcode);
        }
        public async Task<string> PutSinhVienByID(string id, SinhVienDTO sv)
        {
            return await _model.PutSinhVienByID(id, sv);   
        }
        public async Task<bool> deleteSinhVienByID(int id)
        {
            return await _model.deleteSinhVienByID(id);
        }
        public async Task<bool> patchSinhVienByID(int id, JsonPatchDocument<SinhVienDTO> jdoc)
        {
            return await _model.patchSinhVienByID(id,jdoc);
        }
    }
}

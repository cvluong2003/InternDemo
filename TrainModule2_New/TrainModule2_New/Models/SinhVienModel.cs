using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using System.Text.Json;
using Data.EntityModels;


using AutoMapper;
using TrainModule2_New.DTOs;
using SINHVIEN = Data.EntityModels.Sinhvien;

namespace TrainModule2_New.Models
{
    public interface ISinhVienModel
    {
        Task<List<SinhVienDTO>> getall();
        Task<SinhVienDTO> getSinhVienByID(int id);
        Task<SinhVienDTO> CreateSinhVien(SinhVienDTO sv);
        Task<List<SinhVienDTO>> GetSinhVienByClassCode(string classcode);
        Task<string> PutSinhVienByID(string id, SinhVienDTO sv);
        Task<bool> deleteSinhVienByID(int id);
        Task<bool> patchSinhVienByID(int id, JsonPatchDocument<SinhVienDTO> jdoc);
    }
    public class SinhVienModel:ISinhVienModel
    {
        public readonly DBQLSV  _context;
        private readonly IMapper _map;
        public SinhVienModel(DBQLSV context,IMapper map)
        {
            _context = context;
            _map = map;
        }
        public async Task<List<SinhVienDTO>> getall()
        {
            var svs= await _context.Sinhviens.ToListAsync();
            var svsDTO=_map.Map<List<SinhVienDTO>>(svs);
            return svsDTO;
        }
        public async Task<SinhVienDTO> getSinhVienByID(int id)
        {
            var student = await _context.Sinhviens.Where(sv => sv.Masv == id.ToString()).FirstOrDefaultAsync(); ;
            if (student == null)
            {
                return null;
            }
            var studentDTO=_map.Map<SinhVienDTO>(student);
            return studentDTO;
        }
        public async Task<SinhVienDTO> CreateSinhVien(SinhVienDTO sv)
        {
            if (sv == null)
            {
                return null;
            }
            var svef=_map.Map<SINHVIEN>(sv);
            await _context.Sinhviens.AddAsync(svef);
            await _context.SaveChangesAsync();
            return sv;
        }
        public async Task<List<SinhVienDTO>> GetSinhVienByClassCode(string classcode)
        {
            if (classcode.Length == 0)
            {
                return null;
            }
            else
            {
                var dssv = await _context.Sinhviens.Where(sv => sv.Masv == classcode).ToListAsync();
                var dssvDTO=_map.Map<List<SinhVienDTO>>(dssv);
                return dssvDTO;
            }
        }
        public async Task<string> PutSinhVienByID(string id, SinhVienDTO sv)
        {
            if (id == null)
            {
                return "NotFound()";
            }
            else
            {
                if (sv.masv != null && id != sv.masv)
                {
                    return "BadRequest()";
                }
                else
                {
                  
                    _context.Entry(sv).State = EntityState.Modified;
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        return "NotFound()";
                    }
                    return "NoContent()";
                }

            }
        }
        public async Task<bool> deleteSinhVienByID(int id)
        {

            var sv=await _context.Sinhviens.FindAsync(id.ToString());
            if(sv == null)
            {
                return false;
            }
            _context.Remove(sv);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> patchSinhVienByID(int id,JsonPatchDocument<SinhVienDTO> jdoc )
        {
            var sv =await _context.Sinhviens.FindAsync(id.ToString());
            var svdto = _map.Map<SinhVienDTO>(sv);
            if(sv!=null)
            {
                jdoc.ApplyTo(svdto);
                _map.Map(svdto, sv);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

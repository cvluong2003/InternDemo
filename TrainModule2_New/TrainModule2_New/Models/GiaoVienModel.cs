using AutoMapper;
using Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using TrainModule2_New.DTOs;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
namespace TrainModule2_New.Models
{
    public interface IGiaoVienModel
    {
        Task<string> loggin(string ma);
        Task<bool> Register(GiaoVienDTO dto);
        Task<string> changePassWord(string ma, string new_pass);
        Task<bool> checkTeacherCode(string teacherCode);
        Task<bool> VerifyTeacherCodeFromToken(string code);
        Task<List<SinhVienDTO>> getStudentByTeacherCode(string teacherCode);
        Task<List<SinhVienDTO>> GetStudentByClassCode(string teacherCode);
    }
    public class GiaoVienModel:IGiaoVienModel
    {
        public readonly DBQLSV _context;
        public readonly IMapper _imap;
        public GiaoVienModel(DBQLSV context,IMapper imap)
        {
            _context = context; 
            _imap = imap;
        }
        public async Task<string> loggin(string ma)
        {
            var gv =await _context.Giaoviens.Where(s => s.Magv == ma).FirstOrDefaultAsync();
            var gvdto=_imap.Map<GiaoVienDTO>(gv);
            if (gv == null)
            {
                return string.Empty;
            }
            else
            {

                return gv.Pass;
              
               
            }
        }
        public async Task<bool> Register (GiaoVienDTO dto)
        {
            var gv=_imap.Map<Giaovien>(dto);
            if (gv == null)
            {
                return false;
            }
            else
            {
                try
                {
                    await _context.Giaoviens.AddAsync(gv);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch 
                {
                    return false;
                }
            }
        }
        public async Task<string> changePassWord(string ma,string new_pass)
        {
            var gv=await _context.Giaoviens.FindAsync(ma);
            if(gv == null)
            {
                return "404" ;

            }
            else
            {
                try
                {
                    gv.Pass = new_pass;
                    await _context.SaveChangesAsync();
                    return "204";
                }
                catch(Exception ex) 
                {
                    return ex.Message ;
                }
            }
        }
        public async Task<bool> checkTeacherCode(string teacherCode)
        {
            var lst =await _context.Giaoviens.Where(gv => gv.Magv == teacherCode).FirstOrDefaultAsync() ;
            if(lst==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task<bool> VerifyTeacherCodeFromToken(string code)
        {
            var magv =await _context.Giaoviens.Where(gv=>gv.Magv == code).FirstOrDefaultAsync();
            if(magv==null)
                return false;
            return true;
        }
        public async Task<List<SinhVienDTO>> GetStudentByClassCode(string classcode)
        {
            if (classcode.Length == 0)
            {
                return null;
            }
            else
            {
                var dssv = await _context.Sinhviens.Where(sv => sv.Malop == classcode).ToListAsync();
                var dssvDTO = _imap.Map<List<SinhVienDTO>>(dssv);
                return dssvDTO;
            }
        }
        public async Task<List<SinhVienDTO>> getStudentByTeacherCode(string teacherCode)
        {
            var classcode = _context.Giaoviens.Where(gv => gv.Magv == teacherCode).Select(sv => sv.Malop).FirstOrDefault();
            if (classcode == null)
            {
                return null;
            }
            else
            {
                var list = await GetStudentByClassCode(classcode);
                return list;
            }
        }
    }
}

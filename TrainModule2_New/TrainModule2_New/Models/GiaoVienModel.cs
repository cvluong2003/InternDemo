using AutoMapper;
using Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using TrainModule2_New.DTOs;

namespace TrainModule2_New.Models
{
    public interface IGiaoVienModel
    {
        Task<string> loggin(string ma);
        Task<bool> Register(GiaoVienDTO dto);
        Task<string> changePassWord(string ma, string new_pass);
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
    }
}

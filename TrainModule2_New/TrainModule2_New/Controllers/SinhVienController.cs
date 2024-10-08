
using Data.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TrainModule2_New.DTOs;

using TrainModule2_New.Filters;
using TrainModule2_New.Services;
namespace TrainModule2_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sinhvienController : ControllerBase
    {
        private readonly DBQLSV _context = new DBQLSV();
        private readonly ISinhVienService _sinhVienService;
        public sinhvienController(ISinhVienService sinhVienService) {
            //_context = ctx;
            _sinhVienService = sinhVienService;
        }
        [HttpGet]
        public async Task<ActionResult<SinhVienDTO>> GetAll()
        {
            //var dssv =await _sinhVienService.getallSinhVien();
            var dssv = await _context.Sinhviens.ToListAsync();
            return Ok(dssv);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SinhVienDTO>> GetSinhVienByID(int id)
        {
            var sv = await _sinhVienService.getSinhVienByID(id);
            if (sv == null)
            {
                return NotFound();
            }
            return Ok(sv);
        }

        [HttpPost]
        public async Task<ActionResult<SinhVienDTO>> CreateNewSV(SinhVienDTO sv)
        {
            var check = _sinhVienService.CheckSaveSinhVien(sv);
            if (!check.IsValid)
            {
                return BadRequest(check.Errors);
            }
            var sinhvien=await _sinhVienService.createSinhVien(sv);
            if(sinhvien == null)
            {
                return BadRequest("Invalid data");
            }
            return CreatedAtAction(nameof(GetSinhVienByID), new { id = sinhvien.masv }, sinhvien);

        }
        [HttpGet("class")]
        public async Task<ActionResult<SinhVienDTO>> GetStudentbyClassCode([FromQuery] string classcode)
        {
            var dssv = await _sinhVienService.getSinhVienByClassCode(classcode);
            if (dssv.Count == 0 )
            {
                return NotFound();
            }
            else
            {
                return Ok(dssv);
            }
        }
        [HttpPut("{id}")]
        [TokenRequired]
        public async Task<ActionResult<SinhVienDTO>> UpdateStudentByID(string id, [FromBody] SinhVienDTO sv)
        {
           var result=await _sinhVienService.PutSinhVienByID(id, sv);
            if(result== "NotFound()")
            {
                return NotFound();
            }
            else if (result== "BadRequest()")
                {
                return BadRequest();
            }
            else
            {
                return NoContent();
            }
           
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudentByID(int id)
        {
            var result =await _sinhVienService.deleteSinhVienByID(id);
            if(!result)
            {
                return NotFound();
            }
            return NoContent() ;
        }
            [HttpPatch("{id}")]
            public async Task<ActionResult<SinhVienDTO>> PatchStudentByID(int id,[FromBody] JsonPatchDocument<SinhVienDTO> Jdoc)
            {
                if (id.ToString().Length == 0)
                {
                    return NotFound();

                }
                else
                {
                    if (Jdoc == null)
                    {
                        return BadRequest("Patch document is null.");
                    }
                    else
                    {
                        var rs = await _sinhVienService.patchSinhVienByID(id,Jdoc);
                        if(rs)
                        {
                            return NoContent();
                        }
                        return BadRequest("Update Unsuccesfully");
                    }
                }
           
            }

    }
}

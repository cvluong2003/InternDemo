
using Data.EntityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TrainModule2_New.DTOs;
using TrainModule2_New.Validator;
using TrainModule2_New.Filters;
using TrainModule2_New.Services;
namespace TrainModule2_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sinhvienController : ControllerBase
    {
        //private readonly DBQLSV _context;
        private readonly ISinhVienService _sinhVienService;
        private readonly IGiaoVienService _giaoVienService;
        public sinhvienController(ISinhVienService sinhVienService,IGiaoVienService giaoVienService) {
           
            _sinhVienService = sinhVienService;
            _giaoVienService = giaoVienService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SinhVienDTO>>> GetAll([FromHeader] int rowperpage, int page)
        {
           
            if (rowperpage <= 0 || rowperpage == null)
            {
                return BadRequest("Rowperpage undefied");
            }
            else
            {
                if(page<=0)
                {
                    var dssv = await _sinhVienService.getallSinhVien();
                    return Ok(dssv);
                }
                else
                {
                    var allsv = await _sinhVienService.getallSinhVien();
                    var dssv = await _sinhVienService.getWithPaging(allsv,rowperpage, page);
                    if (dssv.Count > 0)
                    {
                        return Ok(dssv);
                    }
                    else
                    {
                        return Content("Page is invalid");
                    }
                }
            }
          
           
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
        [Authorize]
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
        public async Task<ActionResult<SinhVienDTO>> GetStudentbyClassCode([FromQuery] string classcode, [FromQuery] int page, [FromHeader] int rowperpage)
        {
            var dssv = await _sinhVienService.getSinhVienByClassCode(classcode);
            var lst = await _sinhVienService.getWithPaging(dssv, rowperpage, page);
            if(page==null)
            {
                return Ok(dssv);
            }
            else
            {
                if(lst.Count()>0)
                {
                    return Ok(lst);
                }
                else
                {
                    return Content("Page Number is Invalid");
                }
            }
            if (dssv.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(dssv);
            }
        }
        [HttpGet("teacher/{id}")]
        public async Task<ActionResult<List<SinhVienDTO>>> getStudentByTeachercode( string id)
        {
            if(id == null)
            {
                return BadRequest("Invalid Teachercode");
            }
            
            else
            {
                if(!await _giaoVienService.checkTeacherCode(id))
                {
                    return NotFound();
                }
                var lst=await _sinhVienService.getStudentByTeacherCode(id);
                if(lst==null)
                {
                    return new List<SinhVienDTO>();
                }
                else
                {
                    return Ok(lst);
                }
            }
        }
        [HttpPut("{id}")]
        [TokenRequired]
        [Authorize]
        public async Task<ActionResult<SinhVienDTO>> UpdateStudentByID(string id, [FromBody] SinhVienDTO sv)
        {
            var check = _sinhVienService.CheckSaveSinhVien(sv);
            if (!check.IsValid)
            {
                return BadRequest(check.Errors);
            }
        
            var result=await _sinhVienService.PutSinhVienByID(id, sv);
            

            if (result== "NotFound()")
            {
                return NotFound();
            }
            else if (result== "BadRequest()")
                {
                return BadRequest();
            }
            else if(result== "NoContent()")
            {
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        [Authorize]
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
                var check=_sinhVienService.CheckPatchSinhVien(Jdoc);
            if (!check.IsValid)
            {
                return BadRequest(check.Errors);
            }

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

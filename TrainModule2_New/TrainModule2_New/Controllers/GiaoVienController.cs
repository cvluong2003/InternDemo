using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TrainModule2_New.DTOs;
using TrainModule2_New.Services;
namespace TrainModule2_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class GiaoVienController : ControllerBase
    {
        private readonly IGiaoVienService _giaoVienService;
        private readonly TokenService _tokenService;
        public GiaoVienController(IGiaoVienService giaoVienService, TokenService tokenService)
        { 
            _giaoVienService = giaoVienService;
            _tokenService=tokenService;
        }
        [HttpGet] 
        public async Task<ActionResult> Login([FromBody] GiaoVienDTO dto)
        {
           if(dto==null)
            {
                return BadRequest();
            }
           else
            {
               var rs=await _giaoVienService.loggin(dto.Magv,dto.Pass);
                if(rs)
                {
                    
                    var token = _tokenService.GenerateToken(dto.Magv, dto.Pass);
                    return Ok(new { token });
                }
                else
                {
                   
                    return NotFound();
                }
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GiaoVienDTO>> Register([FromBody] GiaoVienDTO dto)
        {
          
            if(dto==null)
            {
                return BadRequest();
            }
            else
            {
                if(await _giaoVienService.Register(dto))
                {
                    return Created();
                }
                else
                {
                    return BadRequest();
                }
            }
        }
    }
}

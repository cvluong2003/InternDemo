using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TrainModule2_New.DTOs;
using TrainModule2_New.Services;
using System.IO;
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
        [HttpPost("login")] 
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
        [HttpPost("register")]
        //[Authorize]
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
        [Authorize]
        [HttpPatch("{id}")]
        public async Task<ActionResult> changepassword( string id,[FromBody] ChangePassWordRequest jdoc)
        {
        
               if(jdoc==null||jdoc.newpass==null||jdoc.oldpass==null ||jdoc.newpass==jdoc.oldpass)
            {
                return BadRequest();
            }
                string result =await _giaoVienService.changePassWord(id,  jdoc.oldpass, jdoc.newpass);
                switch (result)
                {
                    case "404":
                        {
                            return NotFound();
                        }
                    case "204":
                        {
                            return NoContent();

                        }
                    case "400":
                        {
                            return BadRequest();
                        }
                    default:
                        {
                            return StatusCode(500,result);  
                        }
                }
               
            
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TrainModule2_New.DTOs;
using TrainModule2_New.Services;
using System.IO;
using System.Security.Claims;
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
            _tokenService = tokenService;
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] GiaoVienDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            else
            {
                var rs = await _giaoVienService.loggin(dto.Magv, dto.Pass);
                if (rs)
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

            if (dto == null)
            {
                return BadRequest();
            }
            else
            {
                if (await _giaoVienService.Register(dto))
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
        public async Task<ActionResult> changepassword(string id, [FromBody] ChangePassWordRequest jdoc)
        {
            var verify = verifyTeacherFromToken();
            if (verify is OkObjectResult objectResult)
            {
                if (id == objectResult.Value.ToString())
                {
                    if (jdoc == null || jdoc.newpass == null || jdoc.oldpass == null || jdoc.newpass == jdoc.oldpass)
                    {
                        return BadRequest();
                    }
                    string result = await _giaoVienService.changePassWord(id, jdoc.oldpass, jdoc.newpass);
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
                                return StatusCode(500, result);
                            }
                    }
                }
                else
                {
                    return Unauthorized("Cannot access to this resource");
                }
            }
            else if (verify is BadRequestObjectResult badRequest)
            {
                return Unauthorized("Teacher ID is invalid");
            }
            else
            {
                return verify;
            }
        }


        
        [Authorize]
        [HttpGet("gv")]
        public ActionResult verifyTeacherFromToken()
        {
            var magv = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
            if (magv == null)
            {
                return Unauthorized("Không tim thấy mã gv");
            }
            else
            {
               
                return Ok(magv);
            }
        }
        [Authorize]
        [HttpGet("claims")]
        public IActionResult GetClaims()
        {
            // Lấy tất cả các claim của người dùng
            var claims = User.Claims.Select(c => new
            {
                c.Type, // Loại claim (ví dụ: "username", "magv")
                c.Value // Giá trị của claim
            }).ToList();

            // Trả về danh sách claim
            return Ok(claims);
        }
        [Authorize]
        [HttpGet("{teacherCode}/students")]
        public async Task<ActionResult<List<SinhVienDTO>>> getStudentByTeacherID(string teacherCode)
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (!TokenBlackList.checkTokenInBlacklist(token))
            {
                var result = verifyTeacherFromToken();
                string teacherCodeLoggin = string.Empty;
                if (result is OkObjectResult okresouce)
                {
                    teacherCodeLoggin = okresouce.Value.ToString();
                }
                if (teacherCode != teacherCodeLoggin)
                {
                    return Unauthorized("Cannot access to this resource");
                }
                var lstsv = await _giaoVienService.getStudentByTeacherCode(teacherCodeLoggin);
                if (lstsv == null)
                {
                    return new List<SinhVienDTO>();
                }
                else
                {
                    return Ok(lstsv);
                }
            }
            else
            {
                return Unauthorized("Token is expired");
            }
        }
        [Authorize]
        [HttpGet("logout")]
        public ActionResult logout()
        {
            
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            TokenBlackList.addBlackList(token);
            if(TokenBlackList.checkTokenInBlacklist(token))
            {
                return Ok("SignOut Success");
            }
            else
            {
                return BadRequest();
            }
        }
        
    }
}

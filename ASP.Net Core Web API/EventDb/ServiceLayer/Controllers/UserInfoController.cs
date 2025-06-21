using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ServiceLayer.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")] //http://localhost:5022/api/v1.0/UserInfo/
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoRepo<UserInfo> _userInfoRepo;
        private readonly IConfiguration _configuration;

        public UserInfoController(IUserInfoRepo<UserInfo> userInfoRepo, IConfiguration configuration)
        {
            this._userInfoRepo = userInfoRepo;
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllUsers()
        {
            var users = _userInfoRepo.GetAllUsers();
            if (users != null && users.Any())
            {
                return Ok(users); // 200
            }
            else
            {
                return NotFound(); // 404
            }
        }

        [HttpGet]
        [Route("GetByEmail/{emailId}")]
        public IActionResult GetUserByEmail(string emailId)
        {
            var user = _userInfoRepo.GetUserByEmail(emailId);
            if (user != null)
            {
                return Ok(user); // 200
            }
            else
            {
                return NotFound(); // 404
            }
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult AddUser([FromBody] UserInfo user)
        {
            if (ModelState.IsValid)
            {
                var createdUser = _userInfoRepo.AddUser(user);
                return Created(HttpContext.Request.Path, createdUser); // 201
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateUser([FromBody] UserInfo user)
        {
            if (ModelState.IsValid)
            {
                var updatedUser = _userInfoRepo.UpdateUser(user);
                if (updatedUser != null)
                    return Accepted(HttpContext.Request.Path, updatedUser); // 202
                else
                    return NotFound(); // user not found
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("Delete/{emailId}")]
        public IActionResult DeleteUser(string emailId)
        {
            var deletedUser = _userInfoRepo.DeleteUser(emailId);
            if (deletedUser != null)
            {
                return Ok(deletedUser); // 200
            }
            else
            {
                return NotFound(); // 404
            }
        }

        [HttpPost]
        [Route("ValidateUser")]

        public IActionResult ValidateUser([FromBody] UserInfo userInfo)
        {
            var user = _userInfoRepo.ValidateUser(userInfo.EmailId);
            if (user != null)
            {
                //Generate token
                var token = GenerateToken(userInfo);
                return Ok(token);
            }
            else
            {
                return Unauthorized();//401
            }
        }

        [NonAction]
        public string GenerateToken(UserInfo userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingCredential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var claims = new[]
            {
                new Claim(ClaimTypes.Email,userInfo.EmailId),
                new Claim(ClaimTypes.Role,userInfo.Role)
            };

            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: signingCredential);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

using ITIWebApi.PL.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ITIWebApi.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        [HttpPost("login")]
        public IActionResult Login(UserDataDTO user)
        {
            if (user.UserName == "admin" && user.Password == "123")
            {
                //generate token
                #region generate token

                List<Claim> userClaimes = new List<Claim>();
                userClaimes.Add(new Claim("name", user.UserName));
                userClaimes.Add(new Claim(ClaimTypes.MobilePhone, "01032266306"));


                string secretKey = "omniawishy_omniawishy_omniawishy";
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
                var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                var token = new JwtSecurityToken
                (
                    claims: userClaimes,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: signingCredentials


                );

                #endregion 
                string stringToken = new JwtSecurityTokenHandler().WriteToken(token);



                return Ok(stringToken);
            }

            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {


            return Ok();
        }
   }



}

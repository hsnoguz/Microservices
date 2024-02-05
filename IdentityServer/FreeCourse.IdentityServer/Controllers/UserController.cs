﻿using FreeCourse.IdentityServer.Dtos;
using FreeCourse.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using static IdentityServer4.IdentityServerConstants;
using System.IdentityModel.Tokens.Jwt;
namespace FreeCourse.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {

            var user = new ApplicationUser
            {
                UserName = signUpDto.Username,
                Email = signUpDto.Email,
                City = signUpDto.City
            };

            var result = await _userManager.CreateAsync(user, signUpDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 400));
            }

            return NoContent();
            //return Ok(Response<NoContentResult>.Succes(204));
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            if (userIdClaim == null) { 
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(userIdClaim.Value);
            if (user == null) return BadRequest();

            return Ok(new {Id= user.Id, UserName = user.UserName, Email = user.Email, City = user.City});
            {
                
            }

        }

    }
}

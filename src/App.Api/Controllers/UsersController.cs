using Microsoft.AspNetCore.Mvc;
using Users.Application.DTOs;
using Users.Application.Services.Interfaces;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            var id = await _userService.CreateUserAsync(dto);
            return CreatedAtAction(nameof(Create), new { id }, dto);
        }
    }
}

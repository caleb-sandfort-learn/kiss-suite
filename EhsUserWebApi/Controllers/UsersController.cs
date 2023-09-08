using EhsUserWebApi.Data;
using EhsUserWebApi.Models;
using EhsUserWebApi.Service;
using KissRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EhsUserWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly UserMgmtContext _userMgmtContext;
        private readonly UserService _userService;

        public UsersController(UserMgmtContext userMgmtContext, UserService userService)
        {
            _userMgmtContext = userMgmtContext;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();
            var user = await _userService.Get(id);
            if (user == null)
                return NotFound();
            return Ok(user);

        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            return Ok(await _userService.Add(user));
        }

        [HttpPut]
        public async Task<IActionResult> Put(User userData)
        {
            if (userData == null || userData.Identifier == 0)
                return BadRequest();

            var user = await _userService.Get(userData.Identifier);
            if (user == null)
                return NotFound();

            user.FirstName = userData.FirstName;
            user.LastName = userData.LastName;
            user.Email = userData.Email;

            return Ok(await _userService.Update(user));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var user = await _userService.Get(id);
            if (user == null)
                return NotFound();

            return Ok(await _userService.Delete(user));
        }
    }
}

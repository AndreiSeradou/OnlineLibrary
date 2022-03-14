using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BusinessLayer.Interfaces.Services;
using System.Linq;
using BusinessLayer.Models.DTOs.Requests;
using BusinessLayer.Models.DTOs.Responses;

namespace OnlineLibraryBack.Controllers
{
    [Route("api/[controller]")] // api/todo
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "AppUser")]

    public class UserController : ControllerBase
    {
        private readonly IUserService  _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("CreateOrderAsync")]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderRequest model)
        {
            if (ModelState.IsValid)
            {
                var name = User.FindFirst("Name").Value;
                var order =  await _userService.CreateOrderAsync(name, model.BookId).ConfigureAwait(false);

                if (order == false)
                    return NotFound();

                return Ok(order);
            }

            return BadRequest("Something went wrong");
        }

        [HttpGet]
        [Route("GetUserOrdersAsync")]
        public async Task<IActionResult> GetUserOrdersAsync()
        {
            if (ModelState.IsValid)
            {
                var name = User.FindFirst("Name").Value;
                var orders = await _userService.GetAllUserOrdersAsync(name).ConfigureAwait(false);

                if (orders == null)
                    return NotFound();

                return Ok(orders);
            }

            return BadRequest("Something went wrong");
        }

        [HttpGet]
        [Route("GetUserBooksAsync")]
        public async Task<IActionResult> GetUserBooksAsync()
        
        {
            if (ModelState.IsValid)
            {
                var name = User.FindFirst("Name").Value;
                var books = await _userService.GetAllUserBooksAsync(name).ConfigureAwait(false);

                if (books == null)
                    return NotFound();

                return Ok(books);
            }
            return BadRequest("Something went wrong");
        }

        [HttpGet]
        [Route("GetAllBooksAsync")]  
        public async Task<IActionResult> GetAllBooksAsync()
        {
            if (ModelState.IsValid)
            {
                var books = await _userService.GetAllBooksAsync().ConfigureAwait(false);

                if (books == null)
                    return NotFound();

                return Ok(books.ToArray());
            }

            return BadRequest("Something went wrong");
        }
    }
    
}

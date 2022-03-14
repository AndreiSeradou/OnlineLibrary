using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using BusinessLayer.Interfaces.Services;
using System.Linq;
using BusinessLayer.Models.DTOs.Requests;

namespace OnlineLibraryBack.Controllers
{
    [Route("api/[controller]")] // api/todo
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "AppLibrarian")]
    public class LibrarianController : ControllerBase
    {
        private readonly ILibrarianService  _librarianService;

        public LibrarianController(ILibrarianService librarianService)
        {   
            _librarianService = librarianService;
        }

        [HttpPost]
        [Route("CreateBook")]
        public async Task<IActionResult> CreateBook(BookRequest model)
        {
            if (ModelState.IsValid)
            {
                var book = await _librarianService.CreateBookAsync(new Book { Count = model.Count, Name = model.Name, Text = model.Text}).ConfigureAwait(false);
                if (book == null)
                    return NotFound();

                return Ok(book); 
            }

            return BadRequest("Something went wrong");
        }

        [HttpPut]
        [Route("UpdateOrderAsync")]
        public async Task<IActionResult> UpdateOrderAsync(int id)
        {
            if (ModelState.IsValid)
            {
                var order = await _librarianService.UpdateOrderAsync(id).ConfigureAwait(false);

                if (order == null)
                    return NotFound();

                return Ok(order);
            }

            return BadRequest("Something went wrong");
        }

        [HttpGet]
        [Route("GetAllOrdersAsync")]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var orders = await _librarianService.GetAllOrdersAsync().ConfigureAwait(false);

            if (orders == null)
                return NotFound();

            return Ok(orders.Where(o => o.Condition == false));
        }
    }
}
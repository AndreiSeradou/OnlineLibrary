using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BusinessLayer.Interfaces.Services;
using OnlineLibraryBack.Models.DTOs.Requests;
using AutoMapper;
using System.Collections.Generic;
using OnlineLibraryBack.Models.DTOs.Responses;
using Configuration.GeneralConfiguration;
using OnlineLibraryPresentationLayer.DTOs.Requests;

namespace OnlineLibraryBack.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = GeneralConfiguration.UserRole)]

    public class UserController : ControllerBase
    {
        private readonly IUserService  _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        
        [HttpPost]
        [Route("CreateOrderAsync")]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderRequest model)
        {
            if (ModelState.IsValid)
            {
                var name = User.FindFirst(GeneralConfiguration.CustomClaim).Value;
                var result =  await _userService.CreateOrderAsync(name, model.BookId);
        
                return Ok(result);
            }

            return BadRequest(GeneralConfiguration.InvalidModel);
        }

        [HttpGet]
        [Route("GetUserOrdersAsync")]
        public async Task<IActionResult> GetUserOrdersAsync()
        {
            if (ModelState.IsValid)
            {
                var name = User.FindFirst(GeneralConfiguration.CustomClaim).Value;
                var orders = await _userService.GetAllUserOrdersAsync(name);

                if (orders == null)
                    return NotFound();

                var orderResponse = _mapper.Map<IReadOnlyCollection<OrderResponse>>(orders);

                return Ok(orderResponse);
            }

            return BadRequest(GeneralConfiguration.InvalidModel);
        }

        [HttpGet]
        [Route("GetUserBooksAsync")]
        public async Task<IActionResult> GetUserBooksAsync()
        
        {
            if (ModelState.IsValid)
            {
                var name = User.FindFirst(GeneralConfiguration.CustomClaim).Value;
                var books = await _userService.GetAllUserBooksAsync(name);

                if (books == null)
                    return NotFound();

                var booksResponse = _mapper.Map<IReadOnlyCollection<BookResponse>>(books);

                return Ok(booksResponse);
            }
            return BadRequest(GeneralConfiguration.InvalidModel);
        }

        [HttpPost]
        [Route("GetAllBooksAsync")]
        public async Task<IActionResult> GetAllBooksAsync([FromBody] OrderByRequest orderBy)
        {
            if (ModelState.IsValid)
            {
                var books = await _userService.GetAllBooksAsync(orderBy.Text);

                if (books == null)
                    return NotFound();

                var booksResponse = _mapper.Map<IReadOnlyCollection<BookResponse>>(books);

                return Ok(booksResponse);
            }

            return BadRequest(GeneralConfiguration.InvalidModel);
        }

        [HttpPost]
        [Route("GetFilteredBooksAsync")]
        public async Task<IActionResult> GetFilteredBooksAsync([FromBody] FilterByRequest filterBy)
        {
            if (ModelState.IsValid)
            {
                var books = await _userService.GetFilteredBooksAsync(filterBy.Text);

                if (books == null)
                    return NotFound();

                var booksResponse = _mapper.Map<IReadOnlyCollection<BookResponse>>(books);

                return Ok(booksResponse);
            }

            return BadRequest(GeneralConfiguration.InvalidModel);
        }

        [HttpGet]
        [Route("GetOverdueOrdersAsync")]
        public async Task<IActionResult> GetOverdueOrdersAsync()
        {
            if (ModelState.IsValid)
            {
                var name = User.FindFirst(GeneralConfiguration.CustomClaim).Value;
                var orders = await _userService.GetOverdueOrdersAsync(name);

                if (orders == null)
                    return NotFound();

                var booksResponse = _mapper.Map<IReadOnlyCollection<OrderResponse>>(orders);

                return Ok(booksResponse);
            }

            return BadRequest(GeneralConfiguration.InvalidModel);
        }
    }
    
}

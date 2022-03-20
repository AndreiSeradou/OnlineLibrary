using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using BusinessLayer.Interfaces.Services;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using OnlineLibraryBack.Models.DTOs.Requests;
using AutoMapper;
using BusinessLayer.Models.DTOs;
using OnlineLibraryBack.Models.DTOs.Responses;
using System.Collections.Generic;

namespace OnlineLibraryBack.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "AppLibrarian")]
    public class LibrarianController : ControllerBase
    {
        private readonly ILibrarianService  _librarianService;
        private readonly IMapper _mapper;

        public LibrarianController(ILibrarianService librarianService, IMapper mapper)
        {   
            _librarianService = librarianService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CreateBook")]
        public async Task<IActionResult> CreateBook([FromBody] BookRequest model)
        {
            if (ModelState.IsValid)
            {
                var newBook = _mapper.Map<BookBLModel>(model);
                var book = await _librarianService.CreateBookAsync(newBook).ConfigureAwait(false);
                if (book == null)
                    return NotFound();

                return Ok(book); 
            }

            return BadRequest("Something went wrong");
        }

        [HttpPut]
        [Route("UpdateOrderAsync")]
        public async Task<IActionResult> UpdateOrderAsync([FromBody] UpdateOrderRequest model)
        {
            if (ModelState.IsValid)
            {
                var order = await _librarianService.UpdateOrderAsync(model.Id).ConfigureAwait(false);

                if (order == false)
                    return NotFound();

                return Ok(order);
            }

            return BadRequest("Something went wrong");
        }

        [HttpGet]
        [Route("GetAllOrdersConditionFalseAsync")]
        public async Task<IActionResult> GetAllOrdersConditionFalseAsync()
        {
            var orders = await _librarianService.GetAllOrdersAsync().ConfigureAwait(false);

            if (orders == null)
                return NotFound();

            var ordersResponse = _mapper.Map<IReadOnlyCollection<OrderResponse>>(orders);

            return Ok(ordersResponse.Where(o => o.Condition == false));
        }

        [HttpGet]
        [Route("GetAllOrdersConditionTrueAsync")]
        public async Task<IActionResult> GetAllOrdersConditionTrueAsync()
        {
            var orders = await _librarianService.GetAllOrdersAsync().ConfigureAwait(false);

            if (orders == null)
                return NotFound();

            var ordersResponse = _mapper.Map<IReadOnlyCollection<OrderResponse>>(orders);

            return Ok(ordersResponse.Where(o => o.Condition == true));
        }

        [HttpPut]
        [Route("DeleteOrderAsync")]
        public async Task<IActionResult> DeleteOrderAsync([FromBody] UpdateOrderRequest model)
        {
            var orders = await _librarianService.DeleteOrderAsync(model.Id).ConfigureAwait(false);

            if (orders == false)
                return NotFound();

            return Ok(orders);
        }
    }
}
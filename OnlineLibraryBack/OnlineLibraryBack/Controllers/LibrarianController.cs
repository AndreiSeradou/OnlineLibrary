using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interfaces.Services;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using OnlineLibraryBack.Models.DTOs.Requests;
using AutoMapper;
using BusinessLayer.Models.DTOs;
using OnlineLibraryBack.Models.DTOs.Responses;
using System.Collections.Generic;
using Configuration.GeneralConfiguration;

namespace OnlineLibraryBack.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = GeneralConfiguration.LibrarianRole)]
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
                var result = await _librarianService.CreateBookAsync(newBook);
               
                return Ok(result); 
            }

            return BadRequest(GeneralConfiguration.InvalidModel);
        }

        [HttpPost]
        [Route("UpdateOrderAsync")]
        public async Task<IActionResult> UpdateOrderAsync([FromBody] UpdateOrderRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await _librarianService.UpdateOrderAsync(model.Id);

                if (result == false)
                    return NotFound();

                return Ok(result);
            }

            return BadRequest(GeneralConfiguration.InvalidModel);
        }

        [HttpGet]
        [Route("GetAllOrdersConditionFalseAsync")]
        public async Task<IActionResult> GetAllOrdersConditionFalseAsync()
        {
            var orders = await _librarianService.GetAllOrdersConditionFalseAsync();

            if (orders == null)
                return NotFound();  

            return Ok(_mapper.Map<IReadOnlyCollection<OrderResponse>>(orders));
        }

        [HttpGet]
        [Route("GetAllOrdersConditionTrueAsync")]
        public async Task<IActionResult> GetAllOrdersConditionTrueAsync()
        {
            var orders = await _librarianService.GetAllOrdersConditionTrueAsync();

            if (orders == null)
                return NotFound();

            return Ok(_mapper.Map<IReadOnlyCollection<OrderResponse>>(orders));
        }

        [HttpPost]
        [Route("DeleteOrderAsync")]
        public async Task<IActionResult> DeleteOrderAsync([FromBody] UpdateOrderRequest model)
        {
            var result = await _librarianService.DeleteOrderAsync(model.Id);

            if (result == false)
                return NotFound();

            return Ok(result);
        }
    }
}
﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BusinessLayer.Interfaces.Services;
using System.Linq;
using OnlineLibraryBack.Models.DTOs.Requests;
using AutoMapper;
using System.Collections.Generic;
using OnlineLibraryBack.Models.DTOs.Responses;
using Configuration.GeneralConfiguration;

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
                var order =  await _userService.CreateOrderAsync(name, model.BookId).ConfigureAwait(false);

                if (order == false)
                    return NotFound();
        
                return Ok(order);
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
                var orders = await _userService.GetAllUserOrdersAsync(name).ConfigureAwait(false);

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
                var books = await _userService.GetAllUserBooksAsync(name).ConfigureAwait(false);

                if (books == null)
                    return NotFound();

                var booksResponse = _mapper.Map<IReadOnlyCollection<BookResponse>>(books);

                return Ok(booksResponse);
            }
            return BadRequest(GeneralConfiguration.InvalidModel);
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
                var orders = await _userService.GetOverdueOrdersAsync(name).ConfigureAwait(false);

                if (orders == null)
                    return NotFound();

                var booksResponse = _mapper.Map<IReadOnlyCollection<OrderResponse>>(orders);

                return Ok(booksResponse);
            }

            return BadRequest(GeneralConfiguration.InvalidModel);
        }
    }
    
}

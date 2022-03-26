using AutoMapper;
using BusinessLayer.Interfaces.Services;
using BusinessLayer.Models.DTOs;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository  _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public UserService(IBookRepository bookRepository, IUserRepository userRepository, IMapper mapper, IOrderRepository orderRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<bool> CreateOrderAsync(string userId, int bookId)
        {
            var result = await _orderRepository.CreateAsync(userId, bookId);

            if (result != false)
            {
                await _orderRepository.SaveAsync();
            }


            return result;
        }

        public async  Task<IReadOnlyCollection<BookBLModel>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<BookBLModel>>(books);
        }

        public async Task<IReadOnlyCollection<BookBLModel>> GetAllUserBooksAsync(string userId)
        {
            var user = await _userRepository.GetByIdIncludeAllAsync(userId);

            return _mapper.Map<IReadOnlyCollection<BookBLModel>>(user.Books);
        }

        public async Task<IReadOnlyCollection<OrderBLModel>> GetAllUserOrdersAsync(string userId)
        {
            var user = await _userRepository.GetByIdIncludeAllAsync(userId);

            return _mapper.Map<IReadOnlyCollection<OrderBLModel>>(user.Orders);
        }

        public async Task<IReadOnlyCollection<OrderBLModel>> GetOverdueOrdersAsync(string userId)
        {
            var user = await _userRepository.GetByIdIncludeAllAsync(userId);
            var overdueOrders = user.Orders.Where(o => o.DateTimeCreated.Month != DateTime.UtcNow.Month && o.Condition == true);

            return _mapper.Map<IReadOnlyCollection<OrderBLModel>>(overdueOrders);
        }
    }
}

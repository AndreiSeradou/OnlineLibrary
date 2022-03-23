using AutoMapper;
using BusinessLayer.Interfaces.Services;
using BusinessLayer.Models.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
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
        private readonly IMapper _mapper;
        public UserService(IBookRepository bookRepository, IUserRepository userRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateOrderAsync(string userName, int BookId)
        {
            var user = await _userRepository.GetByNameIncludeAllAsync(userName);
            var book = await _bookRepository.GetByIdAsync(BookId);
            var findBook = user.Orders.FirstOrDefault(o => o.Book.Name == book.Name);

            if (user is null || book is null || book.Count <= 0|| findBook != null)
            {
                return false;
            }

            book.Count--;

            user.Orders.Add(new Order { Condition = false, Book = book });

            var result = _userRepository.Update(user);

            if (result is null)
                return false;

            await _bookRepository.SaveAsync();

            return true;
        }

        public async  Task<IReadOnlyCollection<BookBLModel>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<BookBLModel>>(books);
        }

        public async Task<IReadOnlyCollection<BookBLModel>> GetAllUserBooksAsync(string userName)
        {
            var user = await _userRepository.GetByNameIncludeAllAsync(userName);

            return _mapper.Map<IReadOnlyCollection<BookBLModel>>(user.Books);
        }

        public async Task<IReadOnlyCollection<OrderBLModel>> GetAllUserOrdersAsync(string userName)
        {
            var user = await _userRepository.GetByNameIncludeAllAsync(userName);

            return _mapper.Map<IReadOnlyCollection<OrderBLModel>>(user.Orders);
        }

        public async Task<IReadOnlyCollection<OrderBLModel>> GetOverdueOrdersAsync(string userName)
        {
            var user = await _userRepository.GetByNameIncludeAllAsync(userName);
            var overdueOrders = user.Orders.Where(o => o.DateTimeCreated.Month != DateTime.UtcNow.Month && o.Condition == true);

            return _mapper.Map<IReadOnlyCollection<OrderBLModel>>(overdueOrders);
        }
    }
}

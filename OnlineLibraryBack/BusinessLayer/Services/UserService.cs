using AutoMapper;
using OnlineLibrary.BusinessLayer.Interfaces.Services;
using OnlineLibrary.BusinessLayer.Models.DTOs;
using OnlineLibrary.DataAccessLayer.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary.BusinessLayer.Services
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
            var book = await _bookRepository.GetByIdAsync(bookId);
            var order = await _orderRepository.GetByUserIdBookIdAsync(userId, bookId);

            if (order != null || book.Count <= 0)
            {
                return false;
            }

            book.Count--;
         
            await _bookRepository.UpdateAsync(book);

            var result = await _orderRepository.CreateAsync(userId, bookId);

            if (result != false)
            {
                await _orderRepository.SaveAsync();
            }

            return result;
        }

        public async Task<IReadOnlyCollection<BookBLModel>> GetAllBooksAsync(string orderBy)
        {
            var sortedBooks = await _bookRepository.GetAsync(orderBy);
            var sortedResult = _mapper.Map<IReadOnlyCollection<BookBLModel>>(sortedBooks);

            return sortedResult;
        }

        public async  Task<IReadOnlyCollection<BookBLModel>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            var result = _mapper.Map<IReadOnlyCollection<BookBLModel>>(books);

            return result;
        }

        public async Task<IReadOnlyCollection<BookBLModel>> GetFilteredBooksAsync(string filterBy)
        {
            filterBy = filterBy.ToUpper();

            var books = await _bookRepository.GetAllAsync();
            var filteredBooks = books.Where(b => b.Name.ToUpper().Contains(filterBy) || b.Text.ToUpper().Contains(filterBy));
            var result = _mapper.Map<IReadOnlyCollection<BookBLModel>>(filteredBooks);

            return result;
        }

        public async Task<IReadOnlyCollection<BookBLModel>> GetAllUserBooksAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var result = _mapper.Map<IReadOnlyCollection<BookBLModel>>(user.Books);

            return result;
        }

        public async Task<IReadOnlyCollection<OrderBLModel>> GetAllUserOrdersAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var result = _mapper.Map<IReadOnlyCollection<OrderBLModel>>(user.Orders);

            return result;
        }

        public async Task<IReadOnlyCollection<OrderBLModel>> GetOverdueOrdersAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var overdueOrders = user.Orders.Where(o => o.DateTimeCreated.Month != DateTime.UtcNow.Month && o.Condition == true);
            var result = _mapper.Map<IReadOnlyCollection<OrderBLModel>>(overdueOrders);

            return result;
        }
    }
}

using AutoMapper;
using BusinessLayer.Interfaces.Services;
using BusinessLayer.Models.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository  _userRepository;
        private readonly IMapper _mapper;
        public UserService(IBookRepository bookRepository, IUserRepository userRepository, IMapper mapper, IOrderRepository orderRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<bool> CreateOrderAsync(string userName, int BookId, CancellationToken ct = default)
        {
            var user = await _userRepository.GetByNameIncludeOrdersAsync(userName, ct).ConfigureAwait(false);
            var book = await _bookRepository.GetByIdAsync(BookId, ct).ConfigureAwait(false);

            if (user is null || book is null || book.Count <= 0)
            {
                return false;
            }

            book.Count--;

            user.Orders.Add(new Order { Condition = false, Book = book });

            var result = await _userRepository.UpdateAsync(user, ct).ConfigureAwait(false);

            if (!result.Succeeded)
                return false;

            await _bookRepository.SaveAsync();

            return true;
        }

        public async  Task<IReadOnlyCollection<BookBLModel>> GetAllBooksAsync(CancellationToken ct = default)
        {
            var books = await _bookRepository.GetAllAsync(ct).ConfigureAwait(false);
            return _mapper.Map<IReadOnlyCollection<BookBLModel>>(books);
        }

        public async Task<IReadOnlyCollection<BookBLModel>> GetAllUserBooksAsync(string userName, CancellationToken ct = default)
        {
            var user = await _userRepository.GetByNameIncludeAllAsync(userName, ct).ConfigureAwait(false);

            return _mapper.Map<IReadOnlyCollection<BookBLModel>>(user.Books);
        }

        public async Task<IReadOnlyCollection<OrderBLModel>> GetAllUserOrdersAsync(string userName, CancellationToken ct = default)
        {
            var user = await _userRepository.GetByNameIncludeAllAsync(userName, ct).ConfigureAwait(false);

            return _mapper.Map<IReadOnlyCollection<OrderBLModel>>(user.Orders);
        }
    }
}

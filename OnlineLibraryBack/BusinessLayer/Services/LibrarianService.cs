using AutoMapper;
using BusinessLayer.Interfaces.Services;
using BusinessLayer.Models.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Models.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class LibrarianService : ILibrarianService
    {
        private readonly IBookRepository  _bookRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public LibrarianService(IBookRepository bookRepository, IOrderRepository orderRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public  async Task<BookBLModel> CreateBookAsync(BookBLModel model, CancellationToken ct = default)
        {
            var bookModel = _mapper.Map<Book>(model);
            var book = await _bookRepository.CreateAsync(bookModel, ct).ConfigureAwait(false);
            await _bookRepository.SaveAsync();
            return _mapper.Map<BookBLModel>(book);
        }

        public async Task<IReadOnlyCollection<OrderBLModel>> GetAllOrdersAsync(CancellationToken ct = default)
        {
            var orders = await _orderRepository.GetAllAsync(ct).ConfigureAwait(false);
            return _mapper.Map<IReadOnlyCollection<OrderBLModel>>(orders);
        }

        public async Task<bool?> UpdateOrderAsync(int id, CancellationToken ct = default)
        {
            var order = await _orderRepository.GetByIdAsync(id, ct).ConfigureAwait(false);

            order!.Condition = true;

            order.User.Books.Add(order.Book);

            var updateOrder = await _orderRepository.UpdateAsync(order, ct).ConfigureAwait(false);
            
            if (updateOrder is null)
                return false;

            await _orderRepository.SaveAsync();

            return true; 
        }
    }
}

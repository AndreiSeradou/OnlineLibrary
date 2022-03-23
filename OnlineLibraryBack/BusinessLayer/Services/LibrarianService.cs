using AutoMapper;
using BusinessLayer.Interfaces.Services;
using BusinessLayer.Models.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using System;
using System.Collections.Generic;
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

        public  async Task<BookBLModel> CreateBookAsync(BookBLModel model)
        {
            var bookModel = _mapper.Map<Book>(model);
            var book = await _bookRepository.CreateAsync(bookModel);
            await _bookRepository.SaveAsync();
            return _mapper.Map<BookBLModel>(book);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            order.User.Books.Remove(order.Book);
            order.Book.Count++;
            var updateOrder = _orderRepository.Update(order);
            await _orderRepository.DeleteAsync(id);
            await _orderRepository.SaveAsync();

            if (updateOrder is null)
            {
                return false;
            }

            return true;
        }

        public async Task<IReadOnlyCollection<OrderBLModel>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<OrderBLModel>>(orders);
        }

        public async Task<bool> UpdateOrderAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            order.Condition = true;
            order.DateTimeCreated = DateTime.UtcNow;

            order.User.Books.Add(order.Book);

            var updateOrder = _orderRepository.Update(order);
            
            if (updateOrder is null)
                return false;

            await _orderRepository.SaveAsync();

            return true; 
        }

      
    }
}

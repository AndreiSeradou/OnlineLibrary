using AutoMapper;
using OnlineLibrary.BusinessLayer.Interfaces.Services;
using OnlineLibrary.BusinessLayer.Models.DTOs;
using OnlineLibrary.DataAccessLayer.Interfaces.Repositories;
using OnlineLibrary.DataAccessLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary.BusinessLayer.Services
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

        public  async Task<bool> CreateBookAsync(BookBLModel model)
        {
            var bookModel = _mapper.Map<BookEntityModel>(model);

            var result = await _bookRepository.CreateAsync(bookModel);

            if (result != false)
            {
                await _bookRepository.SaveAsync();
            }

            return result;
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            order.Book.Count++;
            order.User.Books.Remove(order.Book);

            await _orderRepository.UpdateAsync(order);
            var result = await _orderRepository.DeleteAsync(orderId);
            
            if (result != false)
            {
                await _orderRepository.SaveAsync();
            }
            return result;
        }

        public async Task<IReadOnlyCollection<OrderBLModel>> GetAllOrdersConditionFalseAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            var result = _mapper.Map<IReadOnlyCollection<OrderBLModel>>(orders.Where(o => o.Condition == false));

            return result;
        }

        public async Task<IReadOnlyCollection<OrderBLModel>> GetAllOrdersConditionTrueAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            var result = _mapper.Map<IReadOnlyCollection<OrderBLModel>>(orders.Where(o => o.Condition == true));

            return result;
        }


        public async Task<bool> UpdateOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId); 

            order.Condition = true;
            order.DateTimeCreated = DateTime.UtcNow;
            order.User.Books.Add(order.Book);
            var result = await _orderRepository.UpdateAsync(order);

            if (result != false)
            {
                await _orderRepository.SaveAsync();
            }

            return result; 
        }
    }
}

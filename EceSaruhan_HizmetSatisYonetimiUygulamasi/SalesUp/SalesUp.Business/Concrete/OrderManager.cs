using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesUp.Business.Abstract;
using SalesUp.Business.Mappings;
using SalesUp.Data.Abstract;
using SalesUp.Entity;
using SalesUp.Shared.ViewModels;

namespace SalesUp.Business.Concrete;

public class OrderManager : IOrderService
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _repository;


    public OrderManager(IMapper mapper, IOrderRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task CreateAsync(Order order)
    {
        await _repository.CreateAsync(order);
    }

    public async Task<List<AdminOrderViewModel>> GetOrdersAsync()
    {
        var orders = await _repository.GetAllAsync(null,
            source => source
                .Include(x => x.OrderDetails)
                .ThenInclude(y => y.Subscription)
                .Include(x => x.User));
        var result = _mapper.Map<List<AdminOrderViewModel>>(orders);
        return result;
    }

    public async Task<List<AdminOrderViewModel>> GetOrdersAsync(string userId)
    {
        var orders = await _repository.GetAllAsync(x => x.UserId == userId,
            source => source
                .Include(x => x.OrderDetails)
                .ThenInclude(y => y.Subscription));
            var result = _mapper.Map<List<AdminOrderViewModel>>(orders);
            return result;
    }

    public async Task<List<AdminOrderViewModel>> GetOrdersAsync(int subscriptionId)
    {
        var orders = await _repository.GetAllOrdersBySubscriptionIdAsync(subscriptionId);
        var result = _mapper.Map<List<AdminOrderViewModel>>(orders);
        return result;
    }

    public async Task<AdminOrderViewModel> GetOrderAsync(int orderId)
    {
        var order = await _repository.GetByIdAsync(x => x.Id == orderId,
            source => source
                .Include(x => x.OrderDetails)
                .ThenInclude(y => y.Subscription));
        var result = _mapper.Map<AdminOrderViewModel>(order);
        return result;
    }
}
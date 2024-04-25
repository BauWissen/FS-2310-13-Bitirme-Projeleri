using AutoMapper;
using SalesUp.Business.Abstract;
using SalesUp.Data.Abstract;
using SalesUp.Entity;
using SalesUp.Shared.ResponseViewModels;
using SalesUp.Shared.ViewModels.Subscription;

namespace SalesUp.Business.Concrete;

public class SubscriptionManager : ISubscriptionService
{
   private readonly IMapper _mapper;
   private readonly ISubscriptionRepository _repository;


   public SubscriptionManager(IMapper mapper, ISubscriptionRepository repository)
   {
      _mapper = mapper;
      _repository = repository;
   }

   public async Task<Response<SubscriptionViewModel>> CreateAsync(AddSubscriptionViewModel addSubscriptionViewModel)
   {
      var subscription = _mapper.Map<Subscription>(addSubscriptionViewModel);
      subscription.CreatedDate = DateTime.Now;
      subscription.UpdateDate = DateTime.Now;
      var createdSubscription = await _repository.CreateAsync(subscription);
      if (subscription == null)
      {
         return Response<SubscriptionViewModel>.Fail("İlgili abonelik oluşturulamadı.");
      }

      await _repository.UpdateAsync(createdSubscription);
      var result = _mapper.Map<SubscriptionViewModel>(createdSubscription);
      return Response<SubscriptionViewModel>.Success(result);
   }

   public async Task<Response<SubscriptionViewModel>> UpdateAsync(EditSubscriptionViewModel editSubscriptionViewModel)
   {
      var editedSubscription = _mapper.Map<Subscription>(editSubscriptionViewModel);
      if (editedSubscription == null)
      {
         return Response<SubscriptionViewModel>.Fail("İlgili abonelik bulunamadı.");
      }
      editedSubscription.UpdateDate = DateTime.Now;
      await _repository.UpdateAsync(editedSubscription);
      var result = _mapper.Map<SubscriptionViewModel>(editedSubscription);
      return Response<SubscriptionViewModel>.Success(result);

   }

   public async Task<Response<NoContent>> HardDeleteAsync(int id)
   {
      var subscription = await _repository.GetByIdAsync(s => s.Id == id);
      if (subscription == null)
      {
         return Response<NoContent>.Fail("İlgili ürün bulunamadı.");
      }
      await _repository.HardDeleteAsync(subscription);
      return Response<NoContent>.Success();
   }

   public async Task<Response<SubscriptionViewModel>> GetByIdAsync(int id)
   {
      var subscription = await _repository.GetByIdAsync(s => s.Id == id);
      if (subscription == null)
      {
         return Response<SubscriptionViewModel>.Fail("İlgili ürün bulunamadı.");
      }
      var subscriptionViewModel = _mapper.Map<SubscriptionViewModel>(subscription);
      return Response<SubscriptionViewModel>.Success(subscriptionViewModel);
   }

   public async Task<Response<List<SubscriptionViewModel>>> GetAllAsync()
   {
      var subscriptions = await _repository.GetAllAsync();
      if (subscriptions == null)
      {
         return Response<List<SubscriptionViewModel>>.Fail("Hiç ürün bulunamadı");
      }
      var result = _mapper.Map<List<SubscriptionViewModel>>(subscriptions);
      return Response<List<SubscriptionViewModel>>.Success(result);
   }
}
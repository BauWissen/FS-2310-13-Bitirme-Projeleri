using System;
using AutoMapper;
using SalesUp.Business.Abstract;
using SalesUp.Data.Abstract;
using SalesUp.Entity;
using SalesUp.Shared.ResponseViewModels;
using SalesUp.Shared.ViewModels;
using SalesUp.Shared.ViewModels.Subscription;

namespace SalesUp.Business.Concrete
{
    public class ContactUsManager : IContactUsService
    {
        private readonly IMapper _mapper;
        private readonly IContactUsRepository _repository;

        public ContactUsManager(IMapper mapper, IContactUsRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<ContactUsViewModel>> CreateAsync(ContactUsViewModel contactUsViewModel)
        {
            var contact = _mapper.Map<ContactUs>(contactUsViewModel);

            var createdContact = await _repository.CreateAsync(contact);
            if (createdContact == null)
            {
                return Response<ContactUsViewModel>.Fail("İlgili kişi eklenemedi.");
            }

            await _repository.UpdateAsync(createdContact);
            var result = _mapper.Map<ContactUsViewModel>(createdContact);
            return Response<ContactUsViewModel>.Success(result);
        }

        public async Task<Response<List<ContactUsViewModel>>> GetAllAsync()
        {
            var contacts = await _repository.GetAllAsync();
            if (contacts == null)
            {
                return Response<List<ContactUsViewModel>>.Fail("Hiç kimse bulunamadı");
            }
            var result = _mapper.Map<List<ContactUsViewModel>>(contacts);
            return Response<List<ContactUsViewModel>>.Success(result);
        }

        public async Task<Response<ContactUsViewModel>> GetByIdAsync(int id)
        {
            var contact = await _repository.GetByIdAsync(c => c.Id == id);
            if (contact == null)
            {
                return Response<ContactUsViewModel>.Fail("İlgili kişi bulunamadı.");
            }
            var contactViewModel = _mapper.Map<ContactUsViewModel>(contact);
            return Response<ContactUsViewModel>.Success(contactViewModel);
        }

        public async Task<Response<NoContent>> HardDeleteAsync(int id)
        {
            var contact = await _repository.GetByIdAsync(c => c.Id == id);
            if (contact == null)
            {
                return Response<NoContent>.Fail("İlgili kişi bulunamadı.");
            }
            await _repository.HardDeleteAsync(contact);
            return Response<NoContent>.Success();
        }

        public async Task<Response<NoContent>> UpdateIsCompletedAsync(int id)
        {
            var contact = await _repository.GetByIdAsync(c => c.Id == id);
            if (contact == null)
            {
                return Response<NoContent>.Fail("İlgili kişi bulunamadı.");
            }
            contact.IsCompleted = !contact.IsCompleted;
  
            await _repository.UpdateAsync(contact);
            return Response<NoContent>.Success();
        }
    }
}


using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Business.Abstract;
using TeamTask.Data.Abstract;
using TeamTask.Entity.Concrete;
using TeamTask.Shared.DTOs.User;
using TeamTask.Shared.Response;

namespace TeamTask.Business.Concrete
{
    public class UserNoteManager : IUserNoteService
    {
        private readonly IUserNoteRepository _userNoteRepository;
        private readonly IMapper _mapper;

        public UserNoteManager(IUserNoteRepository userNoteRepository, IMapper mapper)
        {
            _userNoteRepository = userNoteRepository;
            _mapper = mapper;
        }

        public async Task<APIResponse<UserNoteDTO>> CreateUserNoteAsync(NoteDTO note)
        {
            var userNote = _mapper.Map<UserNote>(note);

           var result = await _userNoteRepository.CreateAsync(userNote);

           var userNoteDto = _mapper.Map<UserNoteDTO>(result);

            return APIResponse<UserNoteDTO>.Success("Notun başarılı bir şekilde oluşturuldu", userNoteDto);
        }

        public async Task<APIResponse<List<UserNoteDTO>>> GetUserAllNoteAsync(string userId)
        {
            var result = await _userNoteRepository.GetAllAsync(u => u.UserId == userId);

            var userNotes = _mapper.Map<List<UserNoteDTO>>(result);
            return APIResponse<List<UserNoteDTO>>.Success("başarılı", userNotes);
        }
    }
}

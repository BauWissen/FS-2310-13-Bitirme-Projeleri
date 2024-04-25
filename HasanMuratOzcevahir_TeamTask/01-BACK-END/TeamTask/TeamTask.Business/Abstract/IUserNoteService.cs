using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Shared.DTOs.Task;
using TeamTask.Shared.DTOs.User;
using TeamTask.Shared.Response;

namespace TeamTask.Business.Abstract
{
    public interface IUserNoteService
    {
        Task<APIResponse<List<UserNoteDTO>>> GetUserAllNoteAsync(string userId);
        Task<APIResponse<UserNoteDTO>> CreateUserNoteAsync(NoteDTO note);
    }
}

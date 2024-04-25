using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SalesUp.Business.Abstract;
using SalesUp.Business.Mappings;
using SalesUp.Data.Abstract;
using SalesUp.Entity;
using SalesUp.Shared.ResponseViewModels;
using SalesUp.Shared.ViewModels.STask;

namespace SalesUp.Business.Concrete;

public class STaskManager : ISTaskService
{
    private readonly IMapper _mapper;
    private readonly ISTaskRepository _repository;

    public STaskManager(ISTaskRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<Response<STaskViewModel>> CreateAsync(AddSTaskViewModel addSTaskViewModel)
    {
        var task = _mapper.Map<STask>(addSTaskViewModel);
        task.CreatedDate = DateTime.Now;
        task.ModifiedDate = DateTime.Now;
        task.IsCompleted = false;
 
        var createdTask = await _repository.CreateAsync(task);
        if (createdTask == null)
        {
            return Response<STaskViewModel>.Fail("Bir hata oluştu");
        }
        await _repository.UpdateAsync(createdTask);
        var taskViewModel = _mapper.Map<STaskViewModel>(createdTask);
        return Response<STaskViewModel>.Success(taskViewModel);
    }

    public async Task<Response<STaskViewModel>> UpdateAsync(EditSTaskViewModel editSTaskViewModel)
    {
        var editedTask = _mapper.Map<STask>(editSTaskViewModel);
        if (editedTask == null)
        {
            return Response<STaskViewModel>.Fail("İlgili görev bulunamadı");
        }
        editedTask.ModifiedDate = DateTime.Now;
        await _repository.UpdateAsync(editedTask);
        var taskViewModel = _mapper.Map<STaskViewModel>(editedTask);
        return Response<STaskViewModel>.Success(taskViewModel);

    }

    public async Task<Response<NoContent>> HardDeleteAsync(int id)
    {
        var task = await _repository.GetByIdAsync(t => t.Id == id);
        if (task == null)
        {
            return Response<NoContent>.Fail("İlgili görev bulunamadı.");
        }

        await _repository.HardDeleteAsync(task);
        return Response<NoContent>.Success();
    }

    public async Task<Response<STaskViewModel>> GetByIdAsync(int id)
    {
        var task = await _repository.GetByIdAsync(t => t.Id == id);
        if (task == null)
        {
            return Response<STaskViewModel>.Fail("İlgili görev bulunamadı.");
        }

        var taskViewModel = _mapper.Map<STaskViewModel>(task);
        return Response<STaskViewModel>.Success(taskViewModel);
    }

    public async Task<Response<List<STaskViewModel>>> GetTasksByUserIdAsync(string userId)
    {
        var taskList = await _repository.GetAllAsync(x => x.UserId == userId,
            source => source
                .Include(x=>x.User));
        if (taskList.Count == 0)
        {
            return Response<List<STaskViewModel>>.Fail("Bu kullanıcıya ait görev bulunamadı.");
        }

        var taskListViewModel = _mapper.Map<List<STaskViewModel>>(taskList);
        return Response<List<STaskViewModel>>.Success(taskListViewModel);
    }

    public async Task<Response<NoContent>> DeleteAllAsync(string userId)
    {
        await _repository.DeleteAllAsync(userId);
        return Response<NoContent>.Success();
    }

    public async Task<Response<NoContent>> UpdateIsCompletedAsync(int id)
    {
        var task = await _repository.GetByIdAsync(t => t.Id == id);
        if (task == null)
        {
            return Response<NoContent>.Fail("İlgili görev bulunamadı.");
        }
        task.IsCompleted = !task.IsCompleted;
        task.ModifiedDate = DateTime.Now;
        await _repository.UpdateAsync(task);
        return Response<NoContent>.Success();
    }

    public async Task<Response<List<STaskViewModel>>> GetAllNonCompletedAsync(string userId,bool isCompleted = false)
    {
        var taskList = await _repository.GetAllAsync(t => t.IsCompleted == isCompleted);
        if (taskList.Count == 0)
        {
            return Response<List<STaskViewModel>>.Fail("Hiç görev bulunamadı.");
            
        }

        var taskListViewModel = _mapper.Map<List<STaskViewModel>>(taskList);
        return Response<List<STaskViewModel>>.Success(taskListViewModel);
    }
}
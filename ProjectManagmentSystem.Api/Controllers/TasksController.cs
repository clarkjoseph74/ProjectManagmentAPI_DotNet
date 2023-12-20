using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectManagmentSystem.Core.DTOs;
using ProjectManagmentSystem.Core.Models;
using ProjectManagmentSystem.Core.Repositories;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectManagmentSystem.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public TasksController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("taskId")]
    public IActionResult GetTaskById(int taskId)
    {
        return Ok(_unitOfWork.Tasks.GetById(taskId));
    }
    [HttpGet]
    public IActionResult GetAll([FromQuery] int? projectId)
    {
        Expression<Func<TaskM, bool>>? criteria = projectId != null ? x => x.ProjectId == projectId : null; 
        var tasks =_unitOfWork.Tasks.GetAll(criteria).Select(x => new TaskDTO
        {
            ProjectId = x.ProjectId,
            Priority = x.Priority,
            Id = x.Id,
            IsCompleted = x.IsCompleted,
            DueDate = x.DueDate,
            Title = x.Title,
            Description = x.Description,
        });
        return Ok(tasks);
    }

    [HttpPost]
    public IActionResult Create(TaskCreateDTO task)
    {
        TaskM taskToAdd = new TaskM
        {
            Title = task.Title,
            Description = task.Description,
             DueDate = task.DueDate,
             IsCompleted = task.IsCompleted,
             Priority = task.Priority,
             ProjectId = task.ProjectId,

        };
        var result = _unitOfWork.Tasks.CreateOne(taskToAdd);
        _unitOfWork.Complete();
        TaskDTO res = new TaskDTO {
        ProjectId = task.ProjectId,
        Priority = task.Priority,
        Id = result.Id,
        IsCompleted= task.IsCompleted,
        DueDate= task.DueDate,
         Title = task.Title,
         Description = task.Description,
        };
        
        return Ok(res);

    }
}

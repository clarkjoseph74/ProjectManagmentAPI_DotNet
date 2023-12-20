using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagmentSystem.Core.DTOs;
using ProjectManagmentSystem.Core.Models;
using ProjectManagmentSystem.Core.Repositories;
using System.Linq.Expressions;

namespace ProjectManagmentSystem.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SubTasksController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public SubTasksController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("taskId")]
    public IActionResult GetTaskById(int taskId)
    {
        return Ok(_unitOfWork.Tasks.GetById(taskId));
    }
    [HttpGet]
    public IActionResult GetAll([FromQuery] int? taskId)
    {
        Expression<Func<SubTask, bool>>? criteria = taskId != null ? x => x.TaskId == taskId : null;
        var tasks = _unitOfWork.SubTasks.GetAll(criteria).Select(x => new SubTaskDTO
        {
            Id = x.Id,
            IsCompleted = x.IsCompleted,
            Title = x.Title,
            Description = x.Description,
            TaskId = x.TaskId,
            
            
        });
        return Ok(tasks);
    }

    [HttpPost]
    public IActionResult Create(SubTaskCreateDTO task)
    {
        SubTask taskToAdd = new SubTask
        {
          Description = task.Description,
          Title = task.Title,
          IsCompleted   = task.IsCompleted,
           TaskId = task.TaskId,

        };
        var result = _unitOfWork.SubTasks.CreateOne(taskToAdd);
        _unitOfWork.Complete();
        SubTaskDTO res = new SubTaskDTO
        {
            
            Id = result.Id,
            IsCompleted = task.IsCompleted,
            Title = task.Title,
            Description = task.Description,
            TaskId = task.TaskId,
            
        };

        return Ok(res);

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagmentSystem.Core.DTOs;
using ProjectManagmentSystem.Core.Models;
using ProjectManagmentSystem.Core.Repositories;

namespace ProjectManagmentSystem.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProjectsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    [HttpGet("projectId")]
    public IActionResult GetOneById(int projectId) {
        return Ok(_unitOfWork.Projects.GetById(projectId));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var projects = _unitOfWork.Projects.GetAll().Select(x => new ProjectDTO
        {
            Id = x.Id,
            Name = x.Name,
            Budget = x.Budget,
            Description = x.Description,
            EndDate = x.EndDate,
            StartDate = x.StartDate 

        });
        return Ok(projects);
    }
    [HttpPut]
    public IActionResult Update(ProjectCreateDTO project)
    {
        Project proj = new Project
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            StartDate = project.StartDate,
            EndDate = project.EndDate,
            Budget = project.Budget,
        };
        var result = _unitOfWork.Projects.UpdateOne(proj);
        _unitOfWork.Complete();
        return Ok(result);

    }
    [HttpPost]
    public IActionResult Create(ProjectCreateDTO project)
    {
        Project proj = new Project
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            StartDate = project.StartDate,
            EndDate = project.EndDate,
            Budget = project.Budget,
        };
        var result = _unitOfWork.Projects.CreateOne(proj);
        _unitOfWork.Complete();
        return Ok(result);

    }
    [HttpDelete("{projectId}")]
    public IActionResult Delete(int projectId)
    {
        var proj = _unitOfWork.Projects.DeleteOne(projectId);
        if(proj != null)
        {
            _unitOfWork.Complete(); 
                    return Ok(proj);
        }
        return NotFound($"Project with Id : {projectId} not exists");
    }
}

using ProjectManagmentSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystem.Core.Repositories;
public interface IUnitOfWork : IDisposable
{
    IBaseRepository<Project> Projects { get; }
    IBaseRepository<TaskM> Tasks { get; }
    IBaseRepository<SubTask> SubTasks { get; }
    int Complete();
}

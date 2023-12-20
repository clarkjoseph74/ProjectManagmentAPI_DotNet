using ProjectManagmentSystem.Core.Models;
using ProjectManagmentSystem.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystem.EF.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
        public IBaseRepository<Project> Projects { get; private set; }

    public IBaseRepository<TaskM> Tasks { get; private set; }

    public IBaseRepository<SubTask> SubTasks { get; private set; }
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Projects = new BaseRepository<Project>(_context);
        Tasks = new BaseRepository<TaskM>(_context);
        SubTasks = new BaseRepository<SubTask>(_context);
    }


    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

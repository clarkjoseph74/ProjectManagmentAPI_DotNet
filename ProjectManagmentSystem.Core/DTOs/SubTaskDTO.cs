using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystem.Core.DTOs;
public class SubTaskDTO
{
    public int Id { get; set; }
    public string Title { get; set; }

    public string Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public int TaskId { get; set; }
}

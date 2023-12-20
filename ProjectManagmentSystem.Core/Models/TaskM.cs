using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystem.Core.Models;
public class TaskM
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    [Required]
    public int Priority { get; set; }
    [Required]
    public int ProjectId { get; set; }
    public bool IsCompleted { get; set; } = false;
    public virtual Project Project { get; set; }

    public virtual ICollection<SubTask> SubTasks { get; set; }

}

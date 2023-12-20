using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystem.Core.Models;
public class SubTask
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public int TaskId { get; set; }
    public virtual TaskM Task { get; set; }
}

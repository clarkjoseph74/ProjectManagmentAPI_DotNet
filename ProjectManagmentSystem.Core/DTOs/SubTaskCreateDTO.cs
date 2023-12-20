using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystem.Core.DTOs;
public class SubTaskCreateDTO
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public bool IsCompleted { get; set; }
    [Required]
    public int TaskId { get; set; }
}

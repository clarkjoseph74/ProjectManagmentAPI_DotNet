using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystem.Core.DTOs;
public class ProjectDTO
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public decimal Budget { get; set; }
}

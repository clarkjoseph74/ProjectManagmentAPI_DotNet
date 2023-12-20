﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystem.Core.DTOs;
public class TaskDTO
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime DueDate { get; set; }

    public int Priority { get; set; }

    public int ProjectId { get; set; }
    public bool IsCompleted { get; set; } = false;
}

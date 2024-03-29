﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace API.Models.Employee
{
    public class Positin
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string PositionName { get; set; }
    }
}

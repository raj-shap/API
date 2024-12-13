﻿using System.ComponentModel.DataAnnotations;

namespace API.Models.Auth
{
    public class Role
    {
        [Required]
        public string id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

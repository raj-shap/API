﻿using Mono.TextTemplating;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Country_DTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CountryName { get; set; }
        public ICollection<State> States { get; set; }
    }
}

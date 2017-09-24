﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorseFromGround.ViewModels
{
    public class StopViewModel
    {
        [Required]
        public string Name { get; set; }
        
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public DateTime Arrival { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationClient.ViewModels
{
    public class TaskViewModel
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
        
        public DateTime? StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class FormDto
    {
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; }
        public int Id { get; set; }
        public object Title { get; set; }
    }
}

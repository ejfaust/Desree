using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desree.DTOs
{
    public class ResumeDto
    {
        public int Id { get; set; }

        public string? Version { get; set; }

        public bool? isDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desree.Models
{
    public class Resume
    {
        public int Id { get; set; }

        public string? Version { get; set; }

        public bool? isDeleted { get; set; }

        public string Secret { get; set; }
    }
}

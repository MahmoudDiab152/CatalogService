using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.DTOs
{
    public class RatingDto
    {
        [Range(0, 5)]
        [Column(TypeName = "decimal(3,2)")]
        public decimal Rate { get; set; }
        public int Count { get; set; }
    }
}

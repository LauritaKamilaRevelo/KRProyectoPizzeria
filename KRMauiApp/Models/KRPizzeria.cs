using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRMauiApp.Models
{
    public class KRPizzeria
    {
        [Key]
        public int idKRPizzeria { get; set; }
        [Required]
        public string? KR_Name { get; set; }
        public bool KR_WithCocaCola { get; set; }
        [Range(0.02, 9999.98)]
        public decimal KR_Precio { get; set; }
    }
}

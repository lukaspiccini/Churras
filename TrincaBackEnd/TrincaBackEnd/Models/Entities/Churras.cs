using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrincaBackEnd.Models.Entities
{
    public class Churras
    {
        [Key]
        [Required]
        public int ChurrasId { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Observacoes { get; set; }
    }
}

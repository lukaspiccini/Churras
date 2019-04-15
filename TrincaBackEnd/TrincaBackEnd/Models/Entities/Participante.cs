using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrincaBackEnd.Models.Entities
{
    public class Participante
    {
        [Key]
        [Required]
        public int ParticipanteId { get; set; }

        [ForeignKey("Churras")]
        [Required]
        public int ChurrasId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public bool ComBebida  { get; set; }

        [Required]
        public decimal Contribuicao { get; set; }

        [Required]
        public bool Pago { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrincaBackEnd.Models.Request
{
    public class ChurrasRequest
    {
        public DateTime Data { get; set; }
        public string Titulo { get; set; }
        public string Observacoes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrincaBackEnd.Models.Entities;

namespace TrincaBackEnd.Repositories
{
    public class ParticipanteRepositorie
    {
        private readonly ChurrasDbContext _context;

        public ParticipanteRepositorie()
        {
            this._context = new ChurrasDbContext();
        }

        public IEnumerable<Participante> GetAll()
        {
            //var teste = from c in _context.Churras
            //            join p in _context.Participantes on c.ChurrasId equals p.ChurrasId
            //            group new { c, p } by new { c.ChurrasId, c.Data, p.Contribuicao } into g
            //            select new
            //            {
            //                g.Key.ChurrasId,
            //                g.Key.Data,
            //                Count = g.Count(),
            //                Arrecadado = g.Sum(x => x.p.Contribuicao)
            //            };

            var participantes = _context.Participantes;
            return participantes;
        }

        public IEnumerable<Participante> GetById(int churrasId)
        {
            var participante = _context.Participantes.Where(x => x.ChurrasId == churrasId).ToList();
            return participante;
        }

        public Participante Create(Participante participante)
        {
            _context.Participantes.Add(participante);
            _context.SaveChanges();

            return participante;
        }

        public Participante Update(Participante participanteEdit)
        {
            var participante = _context.Participantes.Find(participanteEdit.ParticipanteId);

            participante.ComBebida = participanteEdit.ComBebida ;
            participante.Contribuicao = participanteEdit.Contribuicao;
            participante.Pago = participanteEdit.Pago;
            
            _context.SaveChanges();

            return participante;
        }

        public bool Delete(int id)
        {
            var participante = _context.Participantes.Find(id);
            
            _context.Participantes.Remove(participante);

            _context.SaveChanges();

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrincaBackEnd.Models.Entities;
using TrincaBackEnd.Models.Request;

namespace TrincaBackEnd.Repositories
{
    public class ChurrasRepositorie
    {
        private readonly ChurrasDbContext _context;

        public ChurrasRepositorie()
        {
            this._context = new ChurrasDbContext();
        }

        public IEnumerable<Churras> GetAll()
        {
            var churras =  _context.Churras;
            return churras;
        }

        public Churras GetById(int id)
        {
            var churras =  _context.Churras.Find(id);
            return churras;
        }

        public Churras Create(ChurrasRequest churrasRequest)
        {
            Churras churras = new Churras
            {
                Data = churrasRequest.Data,
                Titulo = churrasRequest.Titulo,
                Observacoes = churrasRequest.Observacoes
            };

            var novoChurras = _context.Churras.Add(churras);
            _context.SaveChanges();

            return churras;
        }

        public Churras Update(Churras churrasEdit)
        {
            var churras = _context.Churras.Find(churrasEdit.ChurrasId);

            churras.Data = churrasEdit.Data;
            churras.Titulo = churrasEdit.Titulo;
            churras.Observacoes = churrasEdit.Observacoes;

            _context.SaveChanges();

            return churras;
        }

        public bool Delete(int id)
        {
            var churras = _context.Churras.Find(id);
            var participantes = _context.Participantes.Where(x => x.ChurrasId == id).ToList();
            
            _context.Participantes.RemoveRange(participantes);
            _context.SaveChanges();

            _context.Churras.Remove(churras);
            _context.SaveChanges();

            return true;
        }
    }
}

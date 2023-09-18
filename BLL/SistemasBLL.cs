using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketsApp.DAL;
using TicketsApp.Models;

namespace TicketsApp.BLL
{
    public class SistemasBLL
    {
        private readonly Contexto _contexto;
        public SistemasBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool Existe(int SistemaID)
        {
            return _contexto.Sistemas.Any(s => s.SistemaId == SistemaID);
        }
        public bool Insertar(Sistemas sistemas)
        {
            _contexto.Sistemas.Add(sistemas);
            return _contexto.SaveChanges() > 0;
        }
        public bool Modificar(Sistemas sistemas)
        {
            var p = _contexto.Sistemas.Find(sistemas.SistemaId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(sistemas).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }
        public bool Guardar(Sistemas sistemas)
        {
            if (!Existe(sistemas.SistemaId))
                return this.Insertar(sistemas);
            else
                return this.Modificar(sistemas);
        }
        public bool Eliminar(Sistemas sistemas)
        {
            if (sistemas != null)
            {
                var p = _contexto.Prioridades.Find(sistemas.SistemaId);
                _contexto.Entry(p!).State = EntityState.Detached;
                _contexto.Entry(sistemas).State = EntityState.Deleted;
                return _contexto.SaveChanges() > 0;
            }
            return false;
        }

        public Sistemas? Buscar(int SistemaID)
        {
            return _contexto.Sistemas
                    .AsNoTracking()
                    .SingleOrDefault(p => p.SistemaId == SistemaID);
        }
        public List<Sistemas> Listar(Expression<Func<Sistemas, bool>> Criterio)
        {
            return _contexto.Sistemas
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToList();
        }
    }
}

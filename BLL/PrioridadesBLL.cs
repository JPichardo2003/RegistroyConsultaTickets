using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketsApp.DAL;
using TicketsApp.Models;

namespace TicketsApp.BLL
{
    public class PrioridadesBLL
    {
        private readonly Contexto _contexto;
        public PrioridadesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool Existe(int PrioridadId)
        {
            return _contexto.Prioridades.Any(p => p.PrioridadId == PrioridadId);
        }
        public bool Insertar(Prioridades prioridades)
        {
            _contexto.Prioridades.Add(prioridades);
            return _contexto.SaveChanges() > 0;
        }
        public bool Modificar(Prioridades prioridades)
        {
            var p = _contexto.Prioridades.Find(prioridades.PrioridadId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(prioridades).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }
        public bool Guardar(Prioridades prioridades)
        {
            if (!Existe(prioridades.PrioridadId))
                return this.Insertar(prioridades);
            else
                return this.Modificar(prioridades);
        }
        public bool Eliminar(Prioridades prioridades)
        {
            if (prioridades != null)
            {
                var p = _contexto.Prioridades.Find(prioridades.PrioridadId);
                _contexto.Entry(p!).State = EntityState.Detached;
                _contexto.Entry(prioridades).State = EntityState.Deleted;
                return _contexto.SaveChanges() > 0;
            }
            return false;
        }

        public Prioridades? Buscar(int PrioridadId)
        {
            return _contexto.Prioridades
                    .AsNoTracking()
                    .SingleOrDefault(p => p.PrioridadId == PrioridadId);
        }
        public List<Prioridades> Listar(Expression<Func<Prioridades, bool>> Criterio)
        {
            return _contexto.Prioridades
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToList();
        }
    }
}

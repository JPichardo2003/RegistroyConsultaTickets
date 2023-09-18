using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketsApp.DAL;
using TicketsApp.Models;

namespace TicketsApp.BLL
{
    public class TicketsBLL
    {
        private readonly Contexto _contexto;
        public TicketsBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool Existe(int ticketId)
        {
            return _contexto.Tickets.Any(t => t.TicketId == ticketId);
        }
        public bool Insertar(Tickets ticket)
        {
            _contexto.Tickets.Add(ticket);
            return _contexto.SaveChanges() > 0;
        }
        public bool Modificar(Tickets ticket)
        {
            var p = _contexto.Tickets.Find(ticket.TicketId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(ticket).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }
        public bool Guardar(Tickets ticket)
        {
            if (!Existe(ticket.TicketId))
                return this.Insertar(ticket);
            else
                return this.Modificar(ticket);
        }
        public bool Eliminar(Tickets ticket)
        {
            if (ticket != null)
            {
                var p = _contexto.Tickets.Find(ticket.TicketId);
                _contexto.Entry(p!).State = EntityState.Detached;
                _contexto.Entry(ticket).State = EntityState.Deleted;
                return _contexto.SaveChanges() > 0;
            }
            return false;
        }

        public Tickets? Buscar(int TicketId)
        {
            return _contexto.Tickets
                    .AsNoTracking()
                    .SingleOrDefault(t => t.TicketId == TicketId);
        }
        public List<Tickets> Listar(Expression<Func<Tickets, bool>> Criterio)
        {
            return _contexto.Tickets
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToList();
        }
    }
}

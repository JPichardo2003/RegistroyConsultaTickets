using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketsApp.DAL;
using TicketsApp.Models;

namespace TicketsApp.BLL
{
    public class ClientesBLL
    {
        private readonly Contexto _contexto;
        public ClientesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool Existe(int clienteId)
        {
            return _contexto.Clientes.Any(c => c.ClienteId == clienteId);
        }
        public bool Insertar(Clientes cliente)
        {
            _contexto.Clientes.Add(cliente);
            return _contexto.SaveChanges() > 0;
        }
        public bool Modificar(Clientes cliente)
        {
            var p = _contexto.Clientes.Find(cliente.ClienteId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(cliente).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }
        public bool Guardar(Clientes cliente)
        {
            if (!Existe(cliente.ClienteId))
                return this.Insertar(cliente);
            else
                return this.Modificar(cliente);
        }
        public bool Eliminar(Clientes cliente)
        {
            if (cliente != null)
            {
                var p = _contexto.Clientes.Find(cliente.ClienteId);
                _contexto.Entry(p!).State = EntityState.Detached;
                _contexto.Entry(cliente).State = EntityState.Deleted;
                return _contexto.SaveChanges() > 0;
            }
            return false;
        }

        public Clientes? Buscar(int ClienteId)
        {
            return _contexto.Clientes
                    .AsNoTracking()
                    .SingleOrDefault(p => p.ClienteId == ClienteId);
        }
        public List<Clientes> Listar(Expression<Func<Clientes, bool>> Criterio)
        {
            return _contexto.Clientes
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToList();
        }
    }
}

using CheckpointDigital.Database;
using CheckpointDigital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckpointDigital.Services.Usuarios
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly Contexto _Context;
        public UsuarioServices(Contexto context)
        {
            _Context = context;

        }
        public Usuario Create(Usuario usuario)
        {
            _Context.Usuario.Add(usuario);

            var salvo = _Context.SaveChanges();

            if (salvo > 0)
            {
                return usuario;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var User = GetByID(id);
            if (User == null)
            {
                return false;
            }

            _Context.Usuario.Remove(User);
            _Context.SaveChanges();

            return true;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _Context.Usuario.ToList();
        }

        public Usuario GetByID(int id)
        {
            return _Context.Usuario.Where(x => x.idUsuario == id).FirstOrDefault();
        }

        public Usuario Update(Usuario usuario)
        {

            _Context.Usuario.Update(usuario);
            _Context.SaveChanges();

            return usuario;
        }
    }
}

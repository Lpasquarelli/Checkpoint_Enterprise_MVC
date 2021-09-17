using CheckpointDigital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckpointDigital.Services.Usuarios
{
    public interface IUsuarioServices 
    {
        public IEnumerable<Usuario> GetAll();
        public Usuario GetByID(int id);
        public Usuario Create(Usuario usuario);
        public Usuario Update(Usuario usuario);
        public bool Delete(int id);
    }
}

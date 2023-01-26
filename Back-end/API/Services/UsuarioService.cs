using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DbPruebaTecnicaContext _context;
        private readonly IActvidadservice _actividadservice;
        public UsuarioService(DbPruebaTecnicaContext context, IActvidadservice actividadservice)
        {
            _context = context;
            _actividadservice = actividadservice;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.Where(u => u.Alta == true);
        }

        public async Task<Usuario> GetById(long id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            return usuario;
        }

        public async Task Create(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            await _actividadservice.RegistrarActividad(usuario.IdUsuario, "Creación de usuario");
        }

        public async Task Update(long id, Usuario usuario)
        {
            var usuarioActual = await _context.Usuarios.FindAsync(id);

            if (usuarioActual != null)
            {
                usuarioActual.Nombre = usuario.Nombre;
                usuarioActual.Apellido = usuario.Apellido;
                usuarioActual.CorreoElectronico = usuario.CorreoElectronico;
                usuarioActual.FechaNacimiento = usuario.FechaNacimiento;
                usuarioActual.Telefono = usuario.Telefono;
                usuarioActual.Pais = usuario.Pais;
                usuarioActual.Contacto = usuario.Contacto;
                await _context.SaveChangesAsync();
                await _actividadservice.RegistrarActividad(usuarioActual.IdUsuario, "Actualización de usuario");
            }
        }

        public async Task<bool> SoftDelete(long id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                usuario.Alta = false; 
                await _context.SaveChangesAsync();
                await _actividadservice.RegistrarActividad(usuario.IdUsuario, "Eliminacion de usuario");
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetAll();
        Task<Usuario> GetById(long id);
        Task Create(Usuario usuario);
        Task Update(long id, Usuario usuario);
        Task<bool> SoftDelete(long id);
    }
}
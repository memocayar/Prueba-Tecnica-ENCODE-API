using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class Actvidadservice : IActvidadservice
    {
        private readonly DbPruebaTecnicaContext _context;

        public Actvidadservice(DbPruebaTecnicaContext context)
        {
            _context = context;
        }


        public IEnumerable<Actividad> GetAll()
        {
            return _context.Actividades;
        }

        public async Task<Actividad> GetById(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);
            return actividad;
        }

        public async Task<bool> Delete(int id)
        {
            var actividad = await GetById(id);
            if (actividad != null)
            {
                _context.Actividades.Remove(actividad);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Actividad> RegistrarActividad(long id_usuario, string descripcion)
        {
            var actividad = new Actividad();
            actividad.IdUsuario = id_usuario;
            actividad.descripcion = descripcion;

            _context.Actividades.Add(actividad);
            await _context.SaveChangesAsync();
            return actividad;
        }
    }

    public interface IActvidadservice
    {
        IEnumerable<Actividad> GetAll();
        Task<Actividad> GetById(int id);
        Task<bool> Delete(int id);
        Task<Actividad> RegistrarActividad(long id_usuario, string descripcion);
    }
}
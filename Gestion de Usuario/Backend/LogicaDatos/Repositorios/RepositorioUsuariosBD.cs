﻿using Excepciones;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioUsuariosBD : IRepositorioUsuario
    {
        public GestionUsuariosContext Contexto { get; set; }

        public RepositorioUsuariosBD(GestionUsuariosContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Usuario obj)
        {
            if (obj == null)
            {
                throw new ExcepcionesUsuarios("El Usuario no puede estar vacío");
            }
            if (FindByEmail(obj.Email.Valor) == null && FindByCi(obj.Ci.Valor) == null)
            {
                Contexto.Usuarios.Add(obj);
                Contexto.SaveChanges();
            }
            else
            {
                throw new ExcepcionesUsuarios("Este usuario ya existe");
            }
        }

        public void Delete(int id)
        {
            Usuario user = Contexto.Usuarios.Find(id);
            if (user != null)
            {
                Contexto.Usuarios.Remove(user);
                Contexto.SaveChanges();
            }
            else
            {
                throw new ExcepcionesUsuarios("No se encuentra el usuario");
            }
        }

        public IEnumerable<Usuario> FindAll()
        {
            return Contexto.Usuarios
                .Include(usu => usu.Rol)
                .Include(usu => usu.Eventos)
                .ToList();
        }

        public Usuario FindById(int id)
        {
            if (id == 0)
            {
                throw new ExcepcionesUsuarios("El id del usuario no puede ser 0 o menor");
            }
            if (id == null)
            {
                throw new ExcepcionesUsuarios("El id no puede ser vacío");
            }
            return Contexto.Usuarios
                .Include(usu => usu.Rol)
                .Where(usu => usu.Id == id)
                .FirstOrDefault();
        }

        public void Update(Usuario obj)
        {
            Usuario user = FindById(obj.Id);
            if (user != null)
            {
                Contexto.Entry(user).State = EntityState.Detached;
                Contexto.Usuarios.Update(obj);
                Contexto.SaveChanges();
            }
            else
            {
                throw new ExcepcionesUsuarios("Usuario no Encontrado");
            }
        }

        public Usuario FindByEmail(string email)
        {
            if (email == "" || email == null)
            {
                throw new ExcepcionesUsuarios("El id no puede ser vacío");
            }
            return Contexto.Usuarios
                .Include(usu => usu.Rol)
                .Include(usu => usu.Eventos)
                .Where(usu => usu.Email.Valor == email)
                .FirstOrDefault();
        }

        public Usuario FindByCi(string ci)
        {
            if (ci == "" || ci == null)
            {
                throw new ExcepcionesUsuarios("La ci no puede ser vacía");
            }
            return Contexto.Usuarios
                .Include(usu => usu.Rol)
                .Include(usu => usu.Eventos)
                .Where(usu => usu.Ci.Valor == ci)
                .FirstOrDefault();
        }
    }
}

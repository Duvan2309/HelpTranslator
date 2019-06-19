using HelpTranslator.Interfaces;
using HelpTranslator.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace HelpTranslator.Repositorios
{
    public class UsuarioRepositorio
    {
        private SQLiteConnection conexion;

        public UsuarioRepositorio()
        {
            conexion = DependencyService.Get<ISQLiteInterfaz>().ObtenerConexion();
            conexion.CreateTable<Usuario>();
        }

        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            try
            {
                return (from u in conexion.Table<Usuario>() select u).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public Usuario ObtenerUsuario(int id)
        {
            try
            {
                return conexion.Table<Usuario>().FirstOrDefault(t => t.id == id);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public void EliminarUsuario(int id)
        {
            conexion.Delete<Usuario>(id);
        }
        public string AgregarUsuario(Usuario usuario)
        {
            try
            {
                var datos = conexion.Table<Usuario>();
                var d1 = datos.Where(x => x.correo == usuario.correo).FirstOrDefault();
                if (d1 == null)
                {
                    conexion.Insert(usuario);
                    return "Usuario almacenado exitosamente";
                }
                else
                    return "Usuario ya existe";
            }
            catch (Exception)
            {

                return "Error al ingresar usuario";
            }
        }
        public bool ValidarActualizacionUsuario(string correo)
        {
            try
            {
                var datos = conexion.Table<Usuario>();
                var d1 = (from values in datos
                          where values.correo == correo
                          select values).Single();
                if (d1 != null)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool ActualizarUsuario(string correo, string clave)
        {
            try
            {
                var datos = conexion.Table<Usuario>();
                var d1 = (from values in datos
                          where values.correo == correo
                          select values).Single();

                if (d1 != null)
                {
                    d1.clave = clave;
                    conexion.Update(d1);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool ValidarIngreso(string correo, string clave)
        {
            try
            {
                var data = conexion.Table<Usuario>();
                var d1 = data.Where(x => x.correo == correo && x.clave == clave).FirstOrDefault();
                if (d1 != null)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

using HelpTranslator.Interfaces;
using HelpTranslator.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace HelpTranslator.Repositorios
{
    public class LenguajeRepositorio
    {
        private SQLiteConnection conexion;

        public LenguajeRepositorio()
        {
            conexion = DependencyService.Get<ISQLiteInterfaz>().ObtenerConexion();
            conexion.CreateTable<Lenguajes>();
            InsertarLenguajes();
        }

        public IEnumerable<Lenguajes> ObtenerLenguajes()
        {
            try
            {
                return (from u in conexion.Table<Lenguajes>() select u).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string AgregarLenguaje(Lenguajes lenguaje)
        {
            try
            {
                var datos = conexion.Table<Lenguajes>();
                var d1 = datos.Where(x => x.link == lenguaje.link).FirstOrDefault();
                if (d1 == null)
                {
                    conexion.Insert(lenguaje);
                    return "Lenguaje almacenada exitosamente";
                }
                else
                    return "Lenguaje ya existe";
            }
            catch (Exception)
            {
                return "Error al ingresar Lenguaje";
            }
        }

        public void InsertarLenguajes()
        {
            List<Lenguajes> lenguajes = new List<Lenguajes>()
            {
                new Lenguajes{ link = "https://drive.google.com/open?id=1jRwn7h6FIMf-_ZBw0WVpXcSKmkSowCjy", pais = "Paraguay"},
                new Lenguajes{ link = "https://drive.google.com/open?id=12-zS_UVUhQpL2wokbSB-JycwH6R3RRxP", pais = "Panama"},
                new Lenguajes{ link = "https://drive.google.com/open?id=17mhQIffpnNOFV5HRsdgRS4LUDu04rz0N", pais = "Nicaragua"},
                new Lenguajes{ link = "https://drive.google.com/open?id=1VlZa4AL3hOYxX9RpIu_hvyOHKkFNCJSm", pais = "Cuba"},
                new Lenguajes{ link = "https://drive.google.com/open?id=1nXD_xJlzr1eUT1b_nfOVXvgb7x6aKB38", pais = "Costarica"},
                new Lenguajes{ link = "https://drive.google.com/open?id=106mhHyKbtvsOWcn4OIMZ7OGy3cOHcHi8", pais = "Colombia"},
                new Lenguajes{ link = "https://drive.google.com/open?id=1Loy00FuIxLCfDWfdniL44oLw_dCDelf5", pais = "Brasil"},
                new Lenguajes{ link = "https://drive.google.com/open?id=1vhYFSJmwVJkWVInUPLkIoL_Hv6yTavu6", pais = "Chile"},
                new Lenguajes{ link = "https://drive.google.com/open?id=1J0soZAYeF4ddYR2QwvPHaI9QlfIj4i3G", pais = "España"},
                new Lenguajes{ link = "https://drive.google.com/open?id=1lS1X5uJXooaTV96WEkwK83NHvdTM9Ya4", pais = "Bolivia"}
            };

            foreach (var item in lenguajes)
            {
                AgregarLenguaje(item);
            }
        }
    }
}

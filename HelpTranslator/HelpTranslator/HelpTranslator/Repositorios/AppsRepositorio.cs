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
    public class AppsRepositorio
    {
        private SQLiteConnection conexion;

        public AppsRepositorio()
        {
            conexion = DependencyService.Get<ISQLiteInterfaz>().ObtenerConexion();
            conexion.CreateTable<Apps>();
            InsertarApps();
        }

        public IEnumerable<Apps> ObtenerApps()
        {
            try
            {
                return (from u in conexion.Table<Apps>() select u).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string AgregarApp(Apps apps)
        {
            try
            {
                var datos = conexion.Table<Apps>();
                var d1 = datos.Where(x => x.link == apps.link).FirstOrDefault();
                if (d1 == null)
                {
                    conexion.Insert(apps);
                    return "App almacenada exitosamente";
                }
                else
                    return "App ya existe";
            }
            catch (Exception)
            {
                return "Error al ingresar App";
            }
        }

        public void InsertarApps()
        {
            List<Apps> apps = new List<Apps>()
            {
                new Apps{ link = "https://play.google.com/store/apps/details?id=com.ncatz.yeray.deafmutehelper&hl=es", nombre = "Asistente de sordos y mudos"},
                new Apps{ link = "https://play.google.com/store/apps/details?id=com.yeho.tuvoz&hl=es", nombre = "Sordo Ayuda"},
                new Apps{ link = "https://play.google.com/store/apps/details?id=com.jaguarlabs.lsm&hl=es", nombre = "Dilo en señas"},
                new Apps{ link = "https://play.google.com/store/apps/details?id=ar.com.innoligent.moderndva2&hl=es", nombre = "Despertador para Sordos (mDVA)"},
                new Apps{ link = "https://play.google.com/store/apps/details?id=appinventor.ai_mateo_nicolas_salvatto.Sordos&hl=es", nombre = "Háblalo"},
                new Apps{ link = "https://play.google.com/store/apps/details?id=mimo.language.sign&hl=es", nombre = "aprender lenguaje de señas"},
                new Apps{ link = "https://play.google.com/store/apps/details?id=com.jpgironb.assistiveguru&hl=es", nombre = "Sordo-Mudo Ayudante"},
                new Apps{ link = "https://play.google.com/store/apps/details?id=com.LearnSignLanguageFree.Mimpiandroid&hl=es", nombre = "Aprende el lenguaje de señas gratis"},
                new Apps{ link = "https://play.google.com/store/apps/details?id=com.google.audio.hearing.visualization.accessibility.scribe&hl=es", nombre = "Transcripción instantánea"}
            };

            foreach (var item in apps)
            {
                AgregarApp(item);
            }
        }
    }
}

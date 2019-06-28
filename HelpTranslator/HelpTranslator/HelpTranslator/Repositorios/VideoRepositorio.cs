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
    public class VideoRepositorio
    {
        private SQLiteConnection conexion;

        public VideoRepositorio()
        {
            conexion = DependencyService.Get<ISQLiteInterfaz>().ObtenerConexion();
            conexion.CreateTable<Video>();
            InsertarVideos();
        }

        public IEnumerable<Video> ObtenerVideos()
        {
            try
            {
                return (from u in conexion.Table<Video>() select u).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string AgregarVideo(Video video)
        {
            try
            {
                var datos = conexion.Table<Video>();
                var d1 = datos.Where(x => x.link == video.link).FirstOrDefault();
                if (d1 == null)
                {
                    conexion.Insert(video);
                    return "video almacenada exitosamente";
                }
                else
                    return "video ya existe";
            }
            catch (Exception)
            {
                return "Error al ingresar video";
            }
        }

        public void InsertarVideos()
        {
            List<Video> videos = new List<Video>()
            {
                new Video{ link = "https://youtu.be/EOcVvy1mcYI", nombre = "Vocabulario Básico 1 - Lengua de Señas Colombiana LSC"},
                new Video{ link = "https://youtu.be/q8j1aXIRCv8", nombre = "Vocabulario Básico 2 - Lengua de Señas Colombiana LSC"},
                new Video{ link = "https://youtu.be/-8e3FaA-Rak", nombre = "Vocabulario Básico 3 - Verbos Curso Lengua de Señas Colombiana"},
                new Video{ link = "https://youtu.be/-8e3FaA-Rak", nombre = "Vocabulario Básico 4 - Verbos Curso Lengua de Señas Colombiana"},
                new Video{ link = "https://youtu.be/BTe1ulzazio", nombre = "Lección 1 - Cómo saludar en lengua de señas (LSC)"},
                new Video{ link = "https://youtu.be/xXC_x4Jvnj8", nombre = "Lección 2 - Las diez señas que debes saber (LSC)"},
                new Video{ link = "https://youtu.be/rLL4LJdPRtY", nombre = "10 Señas Básicas (LSM) | Tutorial Rápido"},
                new Video{ link = "https://youtu.be/PO9pBiirH1Q", nombre = "Aprende la Lengua de Señas de tu país con 26 Canales de YouTube"},
                new Video{ link = "https://youtu.be/1MB4zx7Jq-Y", nombre = "SALUDOS Y EXPRESIONES DE CORTESÍA"},
                new Video{ link = "https://youtu.be/R4AkgkXx_yg", nombre = "EMOCIONES"},
                new Video{ link = "https://youtu.be/-D5YsNax_1I", nombre = "ADJETIVOS"},
                new Video{ link = "https://youtu.be/YOhdHDNjxb8", nombre = "¿Quién es una persona sorda? ¿Porqué no somos sordomudos?"},
                new Video{ link = "https://youtu.be/1Q7CBRz7cvY", nombre = "PRONOMBRES INTERROGATIVOS"},
                new Video{ link = "https://youtu.be/wheNDU97YcM", nombre = "FAMILIA"},
                new Video{ link = "https://youtu.be/bDjqgzW8_4w", nombre = "PRONOMBRES"},
                new Video{ link = "https://youtu.be/erzaw5M0QuY", nombre = "No es lenguaje de señas, es Lengua de Señas"},
                new Video{ link = "https://youtu.be/1i3C059nroA", nombre = "¿Qué es Identidad? Y Cuales aspectos no hacen parte de la Identidad Sorda"},
                new Video{ link = "https://youtu.be/8Dtl9FOfaGs", nombre = "Cursos virtuales Lengua de Señas Colombiana"},
                new Video{ link = "https://youtu.be/HGgfpkqF9wA", nombre = "Historia de la LSC - Parte 1"},
                new Video{ link = "https://youtu.be/nYGqvhAnSzw", nombre = "Historia de la LSC - Parte 2"},
                new Video{ link = "https://youtu.be/T-kZevrwooU", nombre = "Historia de la LSC - Parte 3"},
                new Video{ link = "https://youtu.be/7nw1jdO1Gz8", nombre = "Falta de intérprete en distintas partes de Colombia"}
            };

            foreach(var item in videos)
            {
                AgregarVideo(item);
            }
        }
    }
}

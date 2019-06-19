using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpTranslator.Modelos
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string correo { get; set; }
        public string nombre { get; set; }
        public string clave { get; set; }
        public string celular { get; set; }

        public Usuario()
        {

        }
    }
}

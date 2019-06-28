using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpTranslator.Modelos
{
    public class Lenguajes
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string pais { get; set; }
        public string link { get; set; }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpTranslator.Modelos
{
    public class Video
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nombre { get; set; }
        public string link { get; set; }
    }
}

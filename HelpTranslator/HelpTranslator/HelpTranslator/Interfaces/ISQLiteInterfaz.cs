using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpTranslator.Interfaces
{
    public interface ISQLiteInterfaz
    {
        SQLiteConnection ObtenerConexion();
    }
}

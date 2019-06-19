using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HelpTranslator.Droid;
using HelpTranslator.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(ObtenerConexion))]
namespace HelpTranslator.Droid
{
    public class ObtenerConexion : ISQLiteInterfaz
    {
        public ObtenerConexion()
        {

        }
        SQLiteConnection ISQLiteInterfaz.ObtenerConexion()
        {
            var fileName = "HelpTranslator.db3";
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(documentPath, fileName);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}
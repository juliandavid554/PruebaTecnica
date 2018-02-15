using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PruebaTecnica.Interfaces;
using SQLite.Net.Interop;
using Xamarin.Forms;


[assembly: Dependency(typeof(PruebaTecnica.Droid.Confi))]
namespace PruebaTecnica.Droid
{
    class Confi : IConfi
    {
        private string directorioBD;
        private ISQLitePlatform plataform;
        public string DirectorioBD
        {
            get
            {
                if (string.IsNullOrEmpty(directorioBD))
                {
                    //obteniendo el directorio el ios
                    directorioBD = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return directorioBD;
            }
        }
        public ISQLitePlatform Plataforma
        {
            get
            {
                if (plataform == null)
                {
                    plataform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
               
               return plataform;
            }
        }
    }
}
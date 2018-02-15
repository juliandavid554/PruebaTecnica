using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using PruebaTecnica.Interfaces;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(PruebaTecnica.iOS.Confi))]
namespace PruebaTecnica.iOS
{
    class Confi : IConfi
    {
        private string directorioBD;
        private ISQLitePlatform plataform;
        public string DirectorioBD {
            get {
                if (string.IsNullOrEmpty(directorioBD))
                {
                    //obteniendo el directorio el ios
                    var dire = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    directorioBD = System.IO.Path.Combine(dire,"..","library");
                }
                return directorioBD;
            }
        }
        public ISQLitePlatform Plataforma {
            get {
                if (plataform == null)
                {
                    plataform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }

                return plataform;
            }
    }
}
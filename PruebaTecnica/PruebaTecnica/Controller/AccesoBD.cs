using PruebaTecnica.Interfaces;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.IO;
using Prueba.Model;
using System.Linq;

namespace PruebaTecnica.Controller
{
    class AccesoBD : IDisposable
    {
        private SQLiteConnection con;
        //creando constructor para la creacion de la bases de datos
        public AccesoBD() {
            var confi = DependencyService.Get<IConfi>();
            con = new SQLiteConnection(confi.Plataforma, Path.Combine(confi.DirectorioBD, "usuario.db3"));
            con.CreateTable<UsuarioModel>();
        }
        public void Dispose()
        {
            con.Dispose();
        }
        //insertando en la tabla usuario
        public void InsertarUsuario(UsuarioModel u)
        {
            con.Insert(u);
        }
        //actualizando en la tabla usuario
        public void UpdateUsuario(UsuarioModel u)
        {
            con.Update(u);
        }
        //eliminando en la tabla usuario
        public void DeleteUsuario(UsuarioModel u)
        {
            con.Delete(u);
        }
        //obteniendo el usuario
        public UsuarioModel GetUltimoUsuario(string Login)
        {
            return con.Table<UsuarioModel>().FirstOrDefault(c => c.Login == Login);
        }
    }
}

using Prueba.Model;
using Prueba.Util;
using PruebaTecnica.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prueba.Vista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BuscarUsuario : ContentPage
	{
		public BuscarUsuario ()
		{
			InitializeComponent ();
            BtnBuscar.Clicked += BtnBuscar_Clicked;

        }

        private void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            GetJSON(BuscarUsuaro.Text);
        }

        public async void GetJSON(string user)
        {
            //creando el objecto para la bd local con SQlite
            AccesoBD data = new AccesoBD();
            //ProgressLoader.IsRunning = true;
            //valida si tiene conexión a intenet 
            if (NetworkCheck.IsInternet())
            {
                ProgressLoader.IsRunning = true;
                try
                {
                    string texto = BuscarUsuaro.Text;
                    if (BuscarUsuaro.Text != null) {
                        //creando la intencia para leer el we service
                        var client = new System.Net.Http.HttpClient();
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                        client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                        string s = String.Format("https://api.github.com/users/{0}", user);
                        var stringTask = client.GetStringAsync(s);
                        if (stringTask.Id == 2)
                        {
                            ShowDialog("EL usuario no se encuentra");
                            return;
                        }
                        string msg = await stringTask;
                        //serializando el onjecto para leer el string con los datos del web service
                        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(UsuarioModel));
                        MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(msg));
                        UsuarioModel obj = (UsuarioModel)ser.ReadObject(stream);
                        //insertando el usuario nuevo
                        ImgAvatar.Source = obj.AvatarUrl;
                        ImgAvatar.HeightRequest = 150;
                        ImgAvatar.WidthRequest = 150;
                        LblLogin.Text = "Ususario: " + obj.Login;
                        LblName.Text = "Nombre: " + obj.Name;
                        LblCompany.Text = "Empresa: " + obj.Company;
                        LblLocation.Text = "Localización: "+ obj.Location;
                        LblEmail.Text = "Email: " + obj.Email;
                        data.InsertarUsuario(obj);
                        ProgressLoader.IsVisible = false;
                    }
                    else
                    {
                        ProgressLoader.IsRunning = false;
                        ShowDialog("Por favor ingrese un usuario");
                    }

                }
                catch (Exception e)
                {
                    ProgressLoader.IsRunning = false;
                    e.ToString();
                }


            }
            else
            {
                if (BuscarUsuaro.Text != null) {
                    //obteniendo el usuario cuando no tiene conexion a internet
                    UsuarioModel Usuario = data.GetUltimoUsuario(BuscarUsuaro.Text);
                    //validando si es diferente de null
                    if (Usuario != null) {
                        ImgAvatar.Source = Usuario.AvatarUrl;
                        ImgAvatar.HeightRequest = 150;
                        ImgAvatar.WidthRequest = 150;
                        LblLogin.Text = "Ususario: " + Usuario.Login;
                        LblName.Text = "Nombre: " + Usuario.Name;
                        LblCompany.Text = "Empresa: " + Usuario.Company;
                        LblLocation.Text = "Localización: " + Usuario.Location;
                        LblEmail.Text = "Email: " + Usuario.Email;
                    }
                    else
                    {
                        ShowDialog("El usuario no se encuentra en la bases de datos, por favor digite el ultimo usuario.");
                    }
                }
                else
                {
                    ShowDialog("Por favor ingrese un usuario");
                }
            }
            //ProgressLoader.IsRunning = true;
        }
        private void ShowDialog(string mensaje)
        {
            var dialog = DisplayAlert("Alerta", mensaje, "Aceptar");            
        }
    }
}
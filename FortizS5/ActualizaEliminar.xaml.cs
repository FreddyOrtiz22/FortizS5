﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FortizS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualizaEliminar : ContentPage
    {
        public ActualizaEliminar(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();
            txtCodigo.Text = codigo.ToString();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edad.ToString();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues("http://192.168.100.116/ws_uisrael/post.php" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", parametros);
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);

                cliente.UploadValues("http://192.168.100.116/ws_uisrael/post.php" + txtCodigo.Text, "DELETE", parametros);
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }

        }
    }
}
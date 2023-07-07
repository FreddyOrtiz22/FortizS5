using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FortizS5
{
    public partial class MainPage : ContentPage
    {
        private string Url = "http://192.168.100.116/ws_uisrael/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<estudiante> post;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ObtenerDatos();
        }
        private async void ObtenerDatos()
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<estudiante> listaPost = JsonConvert.DeserializeObject<List<estudiante>>(contenido);
            post = new ObservableCollection<estudiante>(listaPost);
            listaestudiante.ItemsSource = post;
        }


        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<estudiante> listaPost = JsonConvert.DeserializeObject<List<estudiante>>(contenido);
            post = new ObservableCollection<estudiante>(listaPost);
            listaestudiante.ItemsSource = post;

        }
    }
}

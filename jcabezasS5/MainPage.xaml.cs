using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jcabezasS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://169.254.31.55/ws_uisrael/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<jcabezasS5.Datos> _post;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<jcabezasS5.Datos> post = JsonConvert.DeserializeObject<List<jcabezasS5.Datos>>(content);
                _post = new ObservableCollection<jcabezasS5.Datos>(post);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                // Manejar el error, ya sea mostrándolo en un mensaje o registrándolo.
            }
        }

        private void btnMostrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());
        }

        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoDatos = (Datos)e.SelectedItem;
            /*
            var codigo = Convert.ToInt32(objetoDatos.codigo.ToString());
            string nombre = objetoDatos.nombre.ToString();
            string apellido = objetoDatos.apellido.ToString();
            int edad = Convert.ToInt32(objetoDatos.edad.ToString());
            */
            Navigation.PushAsync(new AcEliminar(objetoDatos));
        }
    }

}
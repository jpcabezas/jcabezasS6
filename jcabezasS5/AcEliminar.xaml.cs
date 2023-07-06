using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jcabezasS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcEliminar : ContentPage
    {
        public AcEliminar(Datos datos)
        {
            InitializeComponent();
            txtCodigo.Text= datos.codigo.ToString();
            txtNombre.Text= datos.nombre.ToString();
            txtApellido.Text= datos.apellido.ToString();
            txtEdad.Text= datos.edad.ToString();

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                string Url = "http://169.254.31.55/ws_uisrael/post.php";

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                cliente.UploadValues(Url, "PUT", cliente.QueryString = parametros);
                // Implementamos el mensaje TOAST
                var mensaje = "Datos Actualizados";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
                // DisplayAlert("Alerta", "Actualización correcta", "Cerrar");
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
                string Url = "http://169.254.31.55/ws_uisrael/post.php";

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);

                cliente.UploadValues(Url, "DELETE", cliente.QueryString = parametros);
                // Implementamos el mensaje TOAST
                var mensaje = "Datos Eliminados";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
                // DisplayAlert("Alerta", "Eliminación correcta", "Cerrar");
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }

        }
    }
}
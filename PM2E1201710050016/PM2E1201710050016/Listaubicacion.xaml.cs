using PM2E1201710050016.clases;
using PM2E1201710050016.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace PM2E1201710050016
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listaubicacion : ContentPage
    {

      
        Crud crud = new Crud();
        public Listaubicacion()
        {
            InitializeComponent();
            mostrarDatos();
        }



        public async void mostrarDatos()
        {
            try
            {
                var ubicacionList = await crud.getReadUbicacion();


                if (ubicacionList != null)
                {
                    lista.ItemsSource = ubicacionList;
                }

            }
            catch (SQLiteException e)
            {
                await DisplayAlert("Lista", "no hay registros", "ok");

            }


        }
        private async void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var ubicacion = new Ubicacion();

            var obj = (Ubicacion)e.SelectedItem;
            if (!string.IsNullOrEmpty(obj.id.ToString()))
            {
                var listaSeleccionada = await crud.getUbicacionId(obj.id);
                if (listaSeleccionada != null)
                {
                     var getLista = new Lista
                    {
                        id =(listaSeleccionada.id),
                        descripcion_corta = listaSeleccionada.descripcion_corta,
                        latitude=listaSeleccionada.latitude,
                        longitude=listaSeleccionada.longitude,
                        descripcion_ubicacion=listaSeleccionada.descripcion_ubicacion

                    };
                    id.Text = (listaSeleccionada.id).ToString();
                    direccion.Text = (listaSeleccionada.descripcion_corta);
                    direccionlarga.Text = listaSeleccionada.descripcion_ubicacion;
                    latitud.Text = listaSeleccionada.latitude.ToString();
                    longitud.Text = listaSeleccionada.longitude.ToString();

                }

            }


        }

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            var ubicacion = await crud.getUbicacionId(Convert.ToInt32(id.Text));
            if (ubicacion != null)
            {
                await crud.Delete(ubicacion);
                await DisplayAlert("Delete", "Datos Eliminados", "ok");

            }
            else
            {
                await DisplayAlert("Warning", "No ha seleccionado ubicacion para borrar","Ok");
            }

        }

        private async void ShowMapa_Clicked(object sender, EventArgs e)
        {
            var getLista = new Lista
            {
                id = Convert.ToInt32(id.Text),
                descripcion_corta =direccion.Text,
                latitude = Convert.ToDouble(latitud.Text),
                longitude = Convert.ToDouble(longitud.Text),
                descripcion_ubicacion = direccionlarga.Text

            };

            var mapa = new Mapa();
            mapa.BindingContext = getLista;
            await Navigation.PushAsync(mapa);
          

        }
    }
}
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace PM2E1201710050016
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapa : ContentPage
    {
        Lista list = new Lista();
        public Mapa()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Pin pin = new Pin();
            pin.Label = list.descripcion_ubicacion;
            pin.Address = list.descripcion_corta;
            pin.Position = new Position(list.latitude, list.longitude);
            var localizacion = await Geolocation.GetLocationAsync();
            m.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(localizacion.Latitude, localizacion.Longitude), Distance.FromKilometers(1)));
            try
            {
                var localization = CrossGeolocator.Current;
                if (localization != null)
                {
                    localization.PositionChanged += Localization_PositionChanged;
                    if (!localization.IsListening)
                    {
                        await localization.StartListeningAsync(TimeSpan.FromSeconds(10), 100);

                    }
                    var position = await localization.GetPositionAsync();
                    var centroMap = new Position(position.Latitude, position.Longitude);
                    m.MoveToRegion(new MapSpan(centroMap, 1, 1));
                }
            }
            catch (Exception) { }

        }

        private void Localization_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {

            double latitude = list.latitude;
            double longitud=list.longitude;

            var centroMapa = new Position(latitude,longitud);
            m.MoveToRegion(new MapSpan(centroMapa, 1, 1));




        }
    }
}
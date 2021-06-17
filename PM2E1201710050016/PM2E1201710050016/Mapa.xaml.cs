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
   
        public Mapa()
        {
            InitializeComponent();
           
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();


            Pin pin = new Pin
            {
                Label = descr.Text,
                Address = ubic.Text,
                Type = PinType.Generic,
                Position = new Position(Convert.ToDouble(lat.Text), Convert.ToDouble(longit.Text))
            };
            m.Pins.Add(pin);
            m.MoveToRegion(mapSpan: MapSpan.FromCenterAndRadius(new Position(Convert.ToDouble(lat.Text), Convert.ToDouble(longit.Text)), Distance.FromKilometers(1)));
           
            /*var localizacion = await Geolocation.GetLastKnownLocationAsync();
            if (localizacion == null)
            {
                localizacion = await Geolocation.GetLocationAsync();
               

            }
            else
            {
                await DisplayAlert("Warning", "GPS APAGADO", "Ok");
            } 
            m.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(localizacion.Latitude, localizacion.Longitude), Distance.FromKilometers(1)));
           
           
            try
            {
                var localization = CrossGeolocator.Current;

                if (!CrossGeolocator.IsSupported)
                {
                    await DisplayAlert("Error","No se cargo el plugn","Ok");
                }
                {

                }
                if (localization != null)
                {
                    if (localization.IsGeolocationEnabled)
                    {
                         

                        localization.PositionChanged += Localization_PositionChanged;
                        if (!localization.IsListening)
                        {
                            await localization.StartListeningAsync(TimeSpan.FromSeconds(10), 100);
                            await DisplayAlert("Warning", "GPS APAGADO", "Ok");
                        }
                        var centroMap = new Position(Convert.ToDouble(lat.Text), Convert.ToDouble(longit.Text));
                        m.MoveToRegion(new MapSpan(centroMap, 1, 1));
                    }
                   
                
                }
            }
            catch (Exception) { }
          
        }


        private void Localization_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {



            var centroMapa = new Position(e.Position.Latitude, e.Position.Longitude);
            m.MoveToRegion(new MapSpan(centroMapa, 1, 1));



            */
        }
    }
}
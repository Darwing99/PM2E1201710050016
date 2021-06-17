using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PM2E1201710050016.clases ;
using SQLite;
using PM2E1201710050016.model;

namespace PM2E1201710050016
{
    public partial class MainPage : ContentPage
    {
        ValidarDatos validar = new ValidarDatos();
        public MainPage()
        {
            InitializeComponent();
        }

        public async void guardarUbicacion()
        {
          
            double _latitud = ((latitud.Text)==null || latitud.Text=="" ) ? 14.01: Convert.ToDouble(latitud.Text);
            double _longitud = ((longitud.Text) == null || longitud.Text == "") ? -88.01 :Convert.ToDouble(longitud.Text);

            string _descripcion = descripcion_larga.Text;
            string _descripcion_corta = descripcion_corta.Text;
         
            
             if (validar.validarUbicacion(_descripcion))
            {
                await DisplayAlert("Alerta", "Debe describir la ubicacion", "Ok");
                return ;
            }if (validar.validarDescripcionCorta(_descripcion_corta))
            {
                await DisplayAlert("Alerta","Debe escribir una ubicacion corta","Ok");
                return ;
            }
            else
            {


                try
                {
                    Crud crud = new Crud();
                    Conexion conn = new Conexion();
                    var ubicacion = new Ubicacion()
                    {
                        id = 0,
                        latitude = _latitud,
                        longitude = _longitud,
                        descripcion_ubicacion = _descripcion,
                        descripcion_corta = _descripcion_corta

                    };

                    conn.Conn().CreateTable<Ubicacion>();
                    conn.Conn().Insert(ubicacion);
                    await DisplayAlert("Success", "Ubicacion Guardada", "Ok");
                    descripcion_corta.Text = "";
                    descripcion_larga.Text = "";
                }
                catch (SQLiteException e)
                {
                    await DisplayAlert("Warning","Error al guardar","Ok");

                }
               

            }
            
            

        }

        private  void Salvar_Clicked(object sender, EventArgs e)
        {
             guardarUbicacion();
        }
    }
}

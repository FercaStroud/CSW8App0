using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CSWP8App0.Resources;
using System.Windows.Media.Imaging;

namespace CSWP8App0
{
    class Cuadros
    {
        bool estaPrendido = false;
        bool bandera;
        int valor;
        int pos;
        Image imagen = new Image();

        public Cuadros(Grid contenedor)
        {
            imagen.Width = 99;
            imagen.Height = 99;
            imagen.VerticalAlignment = VerticalAlignment.Top;
            imagen.HorizontalAlignment = HorizontalAlignment.Left;
            imagen.Visibility = Visibility.Visible;
            contenedor.Children.Add(imagen);
        }
        public void EsVisible(bool valor)
        {
            if (valor == true) 
            imagen.Visibility = Visibility.Visible;
            else
                imagen.Visibility = Visibility.Collapsed; 
        }
        public void setEvent(EventHandler e)
        {
            imagen.Tap += new EventHandler<System.Windows.Input.GestureEventArgs>(e);
        }
        public void setSource(Uri uri)
        {
            imagen.Source = new BitmapImage(uri); 
        }
        public void setMargin(Thickness x)
        {
            imagen.Margin = x;
        }
        public void setName(String name)
        {
            imagen.Name = name;
        }
        public int Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public Boolean EstaPrendido
        {
            get { return estaPrendido; }
            set { estaPrendido = value; }
        }
    }
}

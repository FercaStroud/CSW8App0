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
using System.Windows.Threading;

namespace CSWP8App0
{
    public partial class MainPage : PhoneApplicationPage
    {
        Random r;
        Grid contenedor;
        Cuadros[] cuadros;
        DispatcherTimer timer1;
        int nColor;
        public MainPage()
        {
            InitializeComponent();
        }
        		
        private void OcultarBotones(String s)
		{
            gridBotones.Visibility = System.Windows.Visibility.Collapsed;
            lbTitulo.Text = s.ToString();
            Init(s);
		}
        private void Init(String s)
        {
            r = new Random();
            contenedor = new Grid();
            cuadros = new Cuadros[20];
            nColor = 0;
            contenedor.Height = gridBotones.Height;
            contenedor.Width = gridBotones.Width;
            contenedor.VerticalAlignment = gridBotones.VerticalAlignment;
            contenedor.HorizontalAlignment = gridBotones.HorizontalAlignment;
            contenedor.Margin = gridBotones.Margin;
            LayoutRoot.Children.Add(contenedor);
            nColor = r.Next(0, 4);
            switch (s)
            {
                case "Facil":
                    Cuadricula(0);
                    break;
                case "Normal":
                    Cuadricula(3);
                    break;
                case "Dificil":
                    Cuadricula(4);
                    break;
            }

        }

        private void Cuadricula(int p)
        {
            int 
                prendidas = r.Next(0,19), 
                ant = 0,
                y = 0,
                x = 0,
                incremento = 99;
            for (int i = 0; i < cuadros.Length; i++) 
            {
                cuadros[i] = new Cuadros(contenedor);
                if (i >= 0 && i <= 4)
                {
                    cuadros[i].setMargin(new Thickness((x + incremento), y, 0, 0));
                    incremento += 99;
                    if (i == 4)
                    {
                        incremento = 99;
                        y += 99;
                    }
                }
                else if (i >= 5 && i <= 9)
                {
                    cuadros[i].setMargin(new Thickness((x + incremento), y, 0, 0));
                    incremento += 99;
                    if (i == 9)
                    {
                        incremento = 99;
                        y += 99;
                    }
                }
                else if (i >= 10 && i <= 14)
                {
                    cuadros[i].setMargin(new Thickness((x + incremento), y, 0, 0));
                    incremento += 99;
                    if (i == 14)
                    {
                        incremento = 99;
                        y += 99;
                    }
                }
                else
                {
                    cuadros[i].setMargin(new Thickness((x + incremento), y, 0, 0));
                    incremento += 99;
                }
                cuadros[i].setEvent(CuadrosClick);
                cuadros[i].Pos = i;
                cuadros[i].setName("cuadro-"+i);
            }
            for (int i = 0; i < p; i++)
            {
                if (ant == prendidas)
                    prendidas = r.Next(0, 19);
                else
                {
                    ant = prendidas;
                    prendidas = r.Next(0, 19);
                }
                cuadros[prendidas].EstaPrendido = true;
            }
            for (int i = 0; i < cuadros.Length; i++) 
                ColocarImagen(i);
        }

        private void CuadrosClick(object sender, EventArgs e)
        {
            if (!ChecarGanador())
            {
                Image AUX = ((Image)sender);
                string strAUX = AUX.Name, strPos = "";
                char[] delimitador = new char[] { '-' };
                foreach (string substr in strAUX.Split(delimitador))
                {
                    strPos = substr;
                }
                int pos = int.Parse(strPos);
                if (pos == 0 || pos == 4 || pos == 15 || pos == 19)
                {
                    switch (pos)
                    {
                        case 0:
                            for (int i = 0; i < 3; i++)
                            {
                                if (i == 2)
                                    i = 5;
                                if (cuadros[i].EstaPrendido == false)
                                    cuadros[i].EstaPrendido = true;
                                else
                                    cuadros[i].EstaPrendido = false;
                                ColocarImagen(i);
                            }
                            break;
                        case 4:
                            for (int i = 3; i <= 5; i++)
                            {
                                if (i == 5)
                                    i = 9;
                                if (cuadros[i].EstaPrendido == false)
                                    cuadros[i].EstaPrendido = true;
                                else
                                    cuadros[i].EstaPrendido = false;
                                ColocarImagen(i);
                            }
                            break;
                        case 15:
                            for (int i = 16; i >= 14; i--)
                            {
                                if (i == 14)
                                {
                                    i = 10;
                                }
                                if (cuadros[i].EstaPrendido == false)
                                    cuadros[i].EstaPrendido = true;
                                else
                                    cuadros[i].EstaPrendido = false;
                                ColocarImagen(i);
                            }
                            break;
                        case 19:
                            for (int i = 18; i <= 20; i++)
                            {
                                if (i == 20)
                                    i = 14;
                                if (cuadros[i].EstaPrendido == false)
                                    cuadros[i].EstaPrendido = true;
                                else
                                    cuadros[i].EstaPrendido = false;
                                ColocarImagen(i);
                                if (i == 14) return;
                            }
                            break;
                    }
                }
                else if ((pos >= 1 && pos <= 3))
                {
                    for (int i = -1; i < 3; i++)
                    {
                        if (i == 2)
                            i = 5;
                        if (cuadros[pos + i].EstaPrendido == false)
                            cuadros[pos + i].EstaPrendido = true;
                        else
                            cuadros[pos + i].EstaPrendido = false;
                        ColocarImagen(pos + i);
                    }
                }
                else if (pos == 5 || pos == 10)
                {
                    for (int i = -5; i <= 10; i += 5)
                    {
                        if (i == 10)
                            i = 1;
                        if (cuadros[pos + i].EstaPrendido == false)
                            cuadros[pos + i].EstaPrendido = true;
                        else
                            cuadros[pos + i].EstaPrendido = false;
                        ColocarImagen(pos + i);
                        if (i == 1)
                            return;
                    }
                }
                else if ((pos >= 6 && pos <= 8) || (pos >= 11 && pos <= 13))
                {
                    for (int i = -1; i < 2; i++)
                    {
                        if (cuadros[pos + i].EstaPrendido == false)
                            cuadros[pos + i].EstaPrendido = true;
                        else
                            cuadros[pos + i].EstaPrendido = false;
                        ColocarImagen(pos + i);
                    }
                    for (int i = -5; i <= 5; i += 5)
                    {
                        if (i != 0)
                        {
                            if (cuadros[pos + i].EstaPrendido == false)
                                cuadros[pos + i].EstaPrendido = true;
                            else
                                cuadros[pos + i].EstaPrendido = false;
                            ColocarImagen(pos + i);
                        }
                    }
                }
                else if (pos == 9 || pos == 14)
                {
                    for (int i = -5; i <= 10; i += 5)
                    {
                        if (i == 10)
                            i = -1;
                        if (cuadros[pos + i].EstaPrendido == false)
                            cuadros[pos + i].EstaPrendido = true;
                        else
                            cuadros[pos + i].EstaPrendido = false;
                        ColocarImagen(pos + i);
                        if (i == -1)
                            return;
                    }
                }
                else if (pos >= 16 && pos <= 18)
                {
                    for (int i = -1; i < 3; i++)
                    {
                        if (i == 2)
                            i = -5;
                        if (cuadros[pos + i].EstaPrendido == false)
                            cuadros[pos + i].EstaPrendido = true;
                        else
                            cuadros[pos + i].EstaPrendido = false;
                        ColocarImagen(pos + i);
                        if (i == -5)
                            return;
                    }
                }
            }
            else 
            {
                for (int i = 0; i < cuadros.Length; i++)
                {
                    cuadros[i].EsVisible(false);
                }
                TextBlock tb = new TextBlock();
                tb.Text = "GANASTE";
                tb.FontSize = 75;
                contenedor.Children.Add(tb);
                tb.Margin = new Thickness(20, 20, 20, 20);
               
                timer1 = new DispatcherTimer();
                timer1.Interval = new TimeSpan(0, 0, 0, 5);
                timer1.Tick += timer1_Tick;
                timer1.Start();
            }
        }
        public void timer1_Tick(object sender, object args)
        {
            contenedor.Visibility = System.Windows.Visibility.Collapsed;
            LayoutRoot.Children.Remove(contenedor);
            gridBotones.Visibility = System.Windows.Visibility.Visible;
            timer1.Stop();
        }
        private void ColocarImagen(int i)
        {
            String
                rutaEncendido = "Assets/encendido"+ nColor + ".png",
                rutaApagado = "Assets/apagada.png";
            if (!cuadros[i].EstaPrendido)
                cuadros[i].setSource(new Uri(rutaApagado, UriKind.RelativeOrAbsolute));
            else
                cuadros[i].setSource(new Uri(rutaEncendido, UriKind.RelativeOrAbsolute));
        }
        private bool ChecarGanador()
        {
            int checa = 0;
            for (int i = 0; i < cuadros.Length; i++)
            {
                if (cuadros[i].EstaPrendido == true)
                    checa++;
            }
            if (checa == 20)
                return true;
            else 
            return false;
        }
        private void btnFacil_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OcultarBotones("Facil");
        }

        private void btnMedio_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OcultarBotones("Normal");
        }

        private void btnDificil_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OcultarBotones("Dificil");
        }
    }
}
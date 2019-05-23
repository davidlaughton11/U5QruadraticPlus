//David Laughton
//May 23, 2019
//Quadratic function

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace u5QuadraticExtended
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void btnInitalize_Click(object sender, RoutedEventArgs e)
        {
            double a;
            double b;
            double c;
            double x;
            //For two roots the second x value
            double x2;
            double discriniment;
            double.TryParse(aInput.Text, out a);
            double.TryParse(bInput.Text, out b);
            double.TryParse(cInput.Text, out c);

            discriniment = b * b - 4 * a * c;

            if (discriniment > 0)
            {
                discriniment = System.Math.Sqrt(discriniment);
                x = ((b * -1) + discriniment) / 2 * a;
                x2 = ((b * -1) - discriniment) / 2 * a;
                lblOutput.Content = "The two roots are x = " + x2 + " and x = " + x;
            }
            else if (discriniment < 0)
            {
                lblOutput.Content = "there are no roots";
            }
            else if (discriniment == 0)
            {
                x = ((b * -1) + discriniment) / 2 * a;
                lblOutput.Content = "The sigle root is x = " + x;
            }

            Ellipse RootOne;
            RootOne = new Ellipse();
            RootOne.Height = 5;
            RootOne.Width = 5;
            RootOne.Fill = Brushes.Black;
            RootOne.Margin = x + 150;

            Graph.Children.Add(RootOne);

        }
    }
}

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
        
        private void btnInitalize_Click(object sender, RoutedEventArgs e )
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

            if (string.IsNullOrWhiteSpace(aInput.Text))
            {
                MessageBox.Show("Enter values");
            }

            else if (string.IsNullOrWhiteSpace(bInput.Text))
            {
                MessageBox.Show("Enter values");
            }

            else if (string.IsNullOrWhiteSpace(cInput.Text))
            {
                MessageBox.Show("Enter values");
            }

            else
            {                
                discriniment = b * b - (4 * a * c);

                if (discriniment > 0)
                {
                    discriniment = System.Math.Sqrt(discriniment);
                    x = ((b * -1) + discriniment) / 2 * a;
                    x2 = ((b * -1) - discriniment) / 2 * a;
                    lblOutput.Content = "The two roots are x = " + x2 + " and x = " + x;

                    Ellipse RootOne;
                    RootOne = new Ellipse();
                    RootOne.Height = 5;
                    RootOne.Width = 5;
                    RootOne.Fill = Brushes.Black;
                    RootOne.Margin = new Thickness(x + 148, 98, 0, 0); ;
                    Graph.Children.Add(RootOne);

                    Ellipse RootTwo;
                    RootTwo = new Ellipse();
                    RootTwo.Height = 5;
                    RootTwo.Width = 5;
                    RootTwo.Fill = Brushes.Black;
                    RootTwo.Margin = new Thickness(x2 + 148, 98, 0, 0); ;
                    Graph.Children.Add(RootTwo);

                    // Create pens.
                    Pen redPen = new Pen(Brushes.Red, 3);
                    Pen greenPen = new Pen(Brushes.Green, 3);

                    // Create points that define curve.
                    Point point1 = new Point(50, 50);
                    Point point2 = new Point(100, 25);
                    Point point3 = new Point(200, 5);
                    Point point4 = new Point(250, 50);
                    Point point5 = new Point(300, 100);
                    Point point6 = new Point(350, 200);
                    Point point7 = new Point(250, 250);
                    Point[] curvePoints = { point1, point2, point3, point4, point5, point6, point7 };

                    // Draw lines between original points to screen.
                    e.Graphics.DrawLines(redPen, curvePoints);
                    

                    Ellipse Quadratic;
                    Quadratic = new Ellipse();
                    Quadratic.Height = 999;
                    Quadratic.Width = 200;
                    Quadratic.Stroke = Brushes.Black;

                    double vertexY;
                    double vertexX;
                    vertexX = (x + x2) / 2;
                    vertexY = a * (vertexX * vertexX) + b * vertexX + c; 

                    if (a > 0)
                    {
                        RotateTransform rotateTransform1 = new RotateTransform(180, 0, 0);
                        Quadratic.RenderTransform = rotateTransform1;
                        Quadratic.Margin = new Thickness(x + 250 + vertexX, 100 + vertexY, 0, 0);
                    }
                    else if (a < 0)
                    {
                        Quadratic.Margin = new Thickness(x + 148 + vertexX, 100 + vertexY, 0, 0);
                    }
                    Graph.Children.Add(Quadratic);
                }

                else if (discriniment < 0)
                {
                    lblOutput.Content = "there are no roots";
                }

                else if (discriniment == 0)
                {
                    x = ((b * -1) + discriniment) / 2 * a;

                    lblOutput.Content = "The sigle root is x = " + x;
                    Ellipse RootOne;
                    RootOne = new Ellipse();
                    RootOne.Height = 5;
                    RootOne.Width = 5;
                    RootOne.Fill = Brushes.Black;
                    RootOne.Margin = new Thickness(x + 148, 98, 0, 0);
                    Graph.Children.Add(RootOne);                   
                }
            }                   
        }
    }
}

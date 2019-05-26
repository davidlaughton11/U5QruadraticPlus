//David Laughton
//May 23, 2019
//Quadratic function graphing from the parent function y = x^2

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
        //Global variables
        private double x;
        private double x2;
        private double vertexY;
        private double vertexX;        

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void btnInitalize_Click(object sender, RoutedEventArgs e )
        {
            //when button is clicked
            double a;
            double b;
            double c;            
            double discriniment;
            //making input in to doubles
            double.TryParse(aInput.Text, out a);
            double.TryParse(bInput.Text, out b);
            double.TryParse(cInput.Text, out c);
            //Make sure values are entered
            if (string.IsNullOrWhiteSpace(bInput.Text) || string.IsNullOrWhiteSpace(cInput.Text)
                || string.IsNullOrWhiteSpace(aInput.Text))
            {
                MessageBox.Show("Enter values");
            }
            //Making sure the numbers entered make a parabola not a linear relationship
            else if (a == 0)
            {
                MessageBox.Show("not quadratics if a is 0");
            }
            else
            {
                discriniment = b * b - (4 * a * c);
                //What to do for two zeros
                if (discriniment > 0)
                {
                    //finding the two zeros
                    discriniment = Math.Sqrt(discriniment);
                    x = ((b * -1) + discriniment) / (2 * a);
                    x2 = ((b * -1) - discriniment) / (2 * a);

                    //graphing the two roots
                    Ellipse RootOne;
                    RootOne = new Ellipse();
                    RootOne.Height = 5;
                    RootOne.Width = 5;
                    RootOne.Fill = Brushes.Blue;
                    RootOne.Margin = new Thickness(x + 256, 102, 0, 0);
                    Graph.Children.Add(RootOne);

                    Ellipse RootTwo;
                    RootTwo = new Ellipse();
                    RootTwo.Height = 5;
                    RootTwo.Width = 5;
                    RootTwo.Fill = Brushes.Blue;
                    RootTwo.Margin = new Thickness(x2 + 256, 102, 0, 0); ;
                    Graph.Children.Add(RootTwo);

                    //finding the vertex
                    vertexX = (x + x2) / 2;
                    vertexY = a * (vertexX * vertexX) + b * vertexX + c;

                    //graphing the quardratic by transforming the parent function y = x^2
                    Ellipse quadratic = new Ellipse();
                    double height = 392 * Math.Abs(a);
                    quadratic.Height = height;
                   
                    quadratic.Width = 28;
                    quadratic.Stroke = Brushes.Black;

                    if (a > 0)
                    {
                        Canvas.SetLeft(quadratic, 244.5 + vertexX);
                        Canvas.SetBottom(quadratic, 104.5 + vertexY);
                    }
                    else
                    {
                        Canvas.SetLeft(quadratic, 244.5 + vertexX);
                        Canvas.SetTop(quadratic, 104.5 + vertexY);
                    }                   

                    Graph.Children.Add(quadratic);
                    lblOutput.Content = "The two roots are x = " + x2 + " and x = " + 
                        x + ".\n" + "Vertex is (" + vertexX + "," + vertexY + ")";
                }
                //If there are no zeros
                else if (discriniment < 0)
                {
                    lblOutput.Content = "there are no roots";
                }
                //If there is one zero
                else if (discriniment == 0)
                {
                    //with the quadratic formula you can only get one with the discriniment being zero
                    x = (b * -1) / 2 * a;
                    
                    //Plotting the zero
                    Ellipse RootOne;
                    RootOne = new Ellipse();
                    RootOne.Height = 5;
                    RootOne.Width = 5;
                    RootOne.Fill = Brushes.Blue;
                    RootOne.Margin = new Thickness(x + 256, 102, 0, 0);
                    Graph.Children.Add(RootOne);

                    vertexX = x;
                    vertexY = a * (vertexX * vertexX) + b * vertexX + c;

                    //THe quadratic
                    Ellipse quadratic = new Ellipse();
                    double height = 392 * Math.Abs(a);
                    quadratic.Height = height;

                    quadratic.Width = 28;
                    quadratic.Stroke = Brushes.Black;
                    //if the parabola is concave up or down 
                    if (a > 0)
                    {                        
                        Canvas.SetLeft(quadratic, 244.5 + vertexX);
                        Canvas.SetBottom(quadratic, 104.5);
                    }
                    else 
                    {
                        Canvas.SetLeft(quadratic, 244.5 + vertexX);
                        Canvas.SetTop(quadratic, 104.5);
                    }
                    //adding the quadratic
                    Graph.Children.Add(quadratic);
                    lblOutput.Content = "The sigle root is x = " + x + ". Vertex is (" + vertexX + "," + vertexY + ")";
                }
            }            
        }        
    }
}

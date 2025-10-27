using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using MathNet.Spatial.Euclidean;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GeometryTester
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var gazeLine = new Line3D(new Point3D(4,4,3),
                                      new Point3D(3,3,2));

            var plane = new Plane(new Point3D(0, 0, 0),
                                  new Point3D(1, 0, 0),
                                  new Point3D(1, 1, 0));

            var ray = new Ray3D(new Point3D(3, 3, 2), gazeLine.Direction);
            var intersection = plane.IntersectionWith(ray);

        }
    }
}

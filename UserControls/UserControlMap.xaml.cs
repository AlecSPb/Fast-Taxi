using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;
using Babat_Taxi.Models;
using Babat_Taxi.Services;
using Microsoft.Maps.MapControl.WPF;



namespace Babat_Taxi.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlMap.xaml
    /// </summary>
    public partial class UserControlMap : UserControl
    {
        
        public UserControlMap()
        {
            pinCar = new Pushpin();
            //pinCar.Background = new ImageBrush(new BitmapImage(new Uri(@"../../Images/mapLogo.png", UriKind.Relative)));
            pinCar.Background = new SolidColorBrush(Colors.Black);
            InitializeComponent();
            Counter = 0;
            CounterRideTaxi = 0;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Tmplocs != null)
            {

                if (Tmplocs[CounterRideTaxi] != Tmplocs[Tmplocs.Count - 1])
                {
                    pinCar.Location = Tmplocs[CounterRideTaxi];
                    CounterRideTaxi++;
                }
                else
                {
                    timer.Stop();
                    ViewManager.CloseTakeRideView();
                    ViewManager.ShowFeedbackView();

                    Counter = 0;
                    CounterRideTaxi = 0;
                    RoadMap.Children.Clear();
                    Tmplocs = null;
                }


            }


        }

        Pushpin pinCar;
        private int CounterRideTaxi;
        private DispatcherTimer timer;
        public int Counter { get; set; }
        private DragPin StartPin;
        private DragPin EndPin;
        private MapLayer RouteLayer;
        private string SessionKey;
        Location tmp;
        LocationCollection Tmplocs;

        


        private void RoadMap_Loaded(Location loc1, Location loc2 = null)
        {
            RoadMap.CredentialsProvider.GetCredentials((c) =>
            {
                SessionKey = c.ApplicationId;


                RouteLayer = new MapLayer();
                RoadMap.Children.Add(RouteLayer);


                StartPin = new DragPin(this.RoadMap)
                {
                    Location = loc1
                };


                StartPin.DragEnd += UpdateRoute;


                RoadMap.Children.Add(StartPin);


                EndPin = new DragPin(this.RoadMap)
                {
                    Location = loc2
                };


                EndPin.DragEnd += UpdateRoute;
                RoadMap.Children.Add(EndPin);
                UpdateRoute(null);
            });
        }
        private async void UpdateRoute(Location loc)
        {
            RouteLayer.Children.Clear();

            var startCoord = LocationToCoordinate(StartPin.Location);
            var endCoord = LocationToCoordinate(EndPin.Location);

            var response = await BingMapsRESTToolkit.ServiceManager.GetResponseAsync(new BingMapsRESTToolkit.RouteRequest()
            {
                Waypoints = new List<BingMapsRESTToolkit.SimpleWaypoint>()
                {
                    new BingMapsRESTToolkit.SimpleWaypoint(startCoord),
                    new BingMapsRESTToolkit.SimpleWaypoint(endCoord)
                },
                BingMapsKey = SessionKey,
                RouteOptions = new BingMapsRESTToolkit.RouteOptions()
                {
                    RouteAttributes = new List<BingMapsRESTToolkit.RouteAttributeType>
                    {
                        BingMapsRESTToolkit.RouteAttributeType.RoutePath
                    }
                }
            });

            if (response != null &&
                response.ResourceSets != null &&
                response.ResourceSets.Length > 0 &&
                response.ResourceSets[0].Resources != null &&
                response.ResourceSets[0].Resources.Length > 0)
            {
                var route = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Route;

                var locs = new LocationCollection();
                Tmplocs = locs;
                for (var i = 0; i < route.RoutePath.Line.Coordinates.Length; i++)
                {
                    locs.Add(new Location(route.RoutePath.Line.Coordinates[i][0], route.RoutePath.Line.Coordinates[i][1]));
                }

                var routeLine = new MapPolyline()
                {
                    Locations = locs,
                    Stroke = new SolidColorBrush(Colors.Green),
                    StrokeThickness = 7,

                };

                RouteLayer.Children.Add(routeLine);
            }
        }

        private BingMapsRESTToolkit.Coordinate LocationToCoordinate(Location loc)
        {
            return new BingMapsRESTToolkit.Coordinate(loc.Latitude, loc.Longitude);
        }

        private BitmapImage GetImageSource(string imageSource)
        {
            var icon = new BitmapImage();
            icon.BeginInit();
            icon.UriSource = new Uri(imageSource, UriKind.Relative);
            icon.EndInit();

            return icon;
        }
        private void RoadMap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Counter < 2)
            {
                // Disables the default mouse double-click action.
                e.Handled = true;

                // Determin the location to place the pushpin at on the map.

                //Get the mouse click coordinates
                Point mousePosition = e.GetPosition(this);
                //Convert the mouse coordinates to a locatoin on the map
                Location pinLocation = RoadMap.ViewportPointToLocation(mousePosition);



                Pushpin pin = new Pushpin();

                if(Counter == 0)
                {
                    pin.Background = new ImageBrush(new BitmapImage(new Uri(@"../../Images/start.png", UriKind.Relative)));
                    //pin.Background = new SolidColorBrush(Colors.Green);
                } else if(Counter == 1)
                {
                    pin.Background = new ImageBrush(new BitmapImage(new Uri(@"../../Images/finish.png", UriKind.Relative)));
                    //pin.Background = new SolidColorBrush(Colors.Red);
                }



                pin.Location = pinLocation;
                RoadMap.Children.Add(pin);
                RoadMap.LocationToViewportPoint(pin.Location);
                

                if (Counter == 0)
                {
                    tmp = pinLocation;
                    Counter++;
                }
                else if (Counter == 1)
                {
                    RoadMap_Loaded(tmp,pinLocation);
                    pinCar.Location = tmp;
                    Counter++;
                }
                
            }

        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Counter = 0;
            CounterRideTaxi = 0;

            RoadMap.Children.Clear();
            Tmplocs = null;
        }

        private void TakeRide_Click(object sender, RoutedEventArgs e)
        {
            if (Counter == 2)
            {
                RoadMap.Children.Add(pinCar);
                RoadMap.LocationToViewportPoint(pinCar.Location);
                ViewManager.ShowTakeRideView();
                timer.Start();
            }
        }
    }
}

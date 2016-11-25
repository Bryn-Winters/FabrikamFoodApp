using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Diagnostics;

namespace FabrikamFoodApp
{
    public class MapPage : ContentPage
    {
        Map map;
        public MapPage()
        {
            Label header = new Label
            {
                Text = "Check out our great locations!",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };


            map = new Map
            {
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Centered on Auckland University 
            map.MoveToRegion (MapSpan.FromCenterAndRadius (new Position (-36.8580612, 174.7692847), Distance.FromKilometers (400)));

            var posFabrikamHamilt = new Position(-37.750756, 175.246359); // Latitude, Longitude
            var posFabrikamCoromandel = new Position(-36.859712, 175.572418); // Latitude, Longitude
            var posChristchurch = new Position(-43.5321, 172.6362); // Latitude, Longitude
            var posPalmerstonnorth = new Position(-40.3523, 175.6082); // Latitude, Longitude

            var FabrikamHamilt = new Pin
            {
                Type = PinType.Place,
                Position = posFabrikamHamilt,
                Label = "Fabrikam Hamilton",
                Address = "custom detail info"
            };
            map.Pins.Add(FabrikamHamilt);

            var FabrikamCoromandel = new Pin
            {
                Type = PinType.Place,
                Position = posFabrikamCoromandel,
                Label = "Fabrikam Coromandel",
                Address = "custom detail info"
            };
            map.Pins.Add(FabrikamCoromandel);

            var Christchurch = new Pin
            {
                Type = PinType.Place,
                Position = posChristchurch,
                Label = "Fabrikam Christchurch",
                Address = "custom detail info"
            };
            map.Pins.Add(Christchurch);

            var Palmerstonnorth = new Pin
            {
                Type = PinType.Place,
                Position = posPalmerstonnorth,
                Label = "Fabrikam Palmerston North",
                Address = "custom detail info"
            };
            map.Pins.Add(Palmerstonnorth);



            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(header);
            stack.Children.Add(map);
            Content = stack;

        }
    }
}
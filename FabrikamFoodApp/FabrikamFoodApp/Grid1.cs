using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FabrikamFoodApp
{
    public class Grid1 : ContentPage
    {
        int count = 1;

        public Grid1()
        {
            var layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = 20
            };

            var grid = new Grid
            {
                RowSpacing = 50
            };

            grid.Children.Add(new Label { Text = "This" }, 0, 0); // Left, First element
            grid.Children.Add(new Label { Text = "text is" }, 1, 0); // Right, First element
            grid.Children.Add(new Label { Text = "in a" }, 0, 1); // Left, Second element
            grid.Children.Add(new Label { Text = "grid!" }, 1, 1); // Right, Second element

            var listView = new ListView();
            listView.ItemsSource = new string[]{
  "mono",
  "monodroid",
  "monotouch",
  "monorail",
  "monodevelop",
  "monotone",
  "monopoly",
  "monomodal",
  "mononucleosis"
};

            //monochrome will not appear in the list because it was added
            //after the list was populated.
            

            var gridButton = new Button { Text = "So is this Button!\nClick me." };
            gridButton.Clicked += delegate
            {
                gridButton.Text = string.Format("Thanks! {0} clicks.", count++);
            };

            layout.Children.Add(grid);
            layout.Children.Add(listView);
            layout.Children.Add(gridButton);

            ObservableCollection<Employees> employeeList = new ObservableCollection<Employees>();
            listView.ItemsSource = employeeList;

            //Mr. Mono will be added to the ListView because it uses an ObservableCollection
            employeeList.Add(new Employee() { DisplayName = "Mr. Mono" });

            //listView.ItemsSource.Add("monochrome");
            Content = layout;

        }
    }
}
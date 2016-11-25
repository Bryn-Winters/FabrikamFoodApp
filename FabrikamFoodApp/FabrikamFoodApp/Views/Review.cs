using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Collections.ObjectModel;
using FabrikamFoodApp.DataModels;
using Xamarin.Forms;
using FabrikamFoodApp;
using Microsoft.WindowsAzure.MobileServices;

namespace FabrikamFoodApp
{
    public class Review : ContentPage
    {
        //int count = 1;

        Dictionary<string, int> dishes = new Dictionary<string, int>
        {
            { "Chicken", 1}, { "Fish", 2 },
            { "Dessert", 3 }, { "Maroon Mackerel", 4},
            { "Ice Cream", 5 }, { "Olives", 6 },
            { "Purple Mousse", 7 }, { "Red Turnip", 8 },
            { "Silver Spoon", 9 }, { "Radish", 10 },
            { "Asparagus", 11 }, { "Brocolli", 12 }
        };

        Dictionary<string, int> rating = new Dictionary<string, int>
        {
            { "0.5 Stars", 0}, { "1 Star", 1}, { "1.5 Stars", 2}, { "2 Stars", 3 }, { "2.5 Stars", 4 },
            { "3 Stars", 5 }, { "3.5 Stars", 6 }, { "4 Stars", 7}, { "4.5 Stars", 8},
            { "5 Stars", 9 }
        };
        public static string dishName = "test";
        public static string RatingType = "data";
        public static string edittingID = "test";
        public static bool newInput = true;

        public Review(string input)
        {
            var layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = 20
            };
            
            if(input != null)
            {
                newInput = false;
            }
            edittingID = input;

            Label header = new Label
            {
                Text = "Review Placer",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            if (newInput == false)
            {

                header.Text = "Review Editor";
                
            }

            Picker picker = new Picker
            {
                Title = "Dish",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            foreach (string dishName in dishes.Keys)
            {
                picker.Items.Add(dishName);
            }


            Picker RatingPicker = new Picker
            {
                Title = "Rating",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            foreach (string Ratingtype in rating.Keys)
            {
                RatingPicker.Items.Add(Ratingtype);
            }


            /*// Create BoxView for displaying picked Color
            BoxView boxView = new BoxView
            {
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };*/

            picker.SelectedIndexChanged += (sender, args) =>
            {
                dishName = picker.Items[picker.SelectedIndex];
            };

            RatingPicker.SelectedIndexChanged += (sender, args) =>
            {
                RatingType = RatingPicker.Items[RatingPicker.SelectedIndex];
            };


            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);


            var reviewButton = new Button { Text = "Place Review!\nClick here." };
            reviewButton.Clicked += reviewButton_clicked;


            //layout.Children.Add(listView);
            layout.Children.Add(header);
            layout.Children.Add(picker);
            layout.Children.Add(RatingPicker);
            //layout.Children.Add(boxView);
            layout.Children.Add(reviewButton);

            Content = layout;

        }
        //reviewButton.Clicked += delegate
        //{
        private async void reviewButton_clicked(object sender, EventArgs e)
        {

            try
            {
                if(newInput == true) { 
                ReviewClass yourRating = new ReviewClass()
                {
                    Meal = dishName,
                    Rating = RatingType,
                    Date = DateTime.Now
                };
                    await ReviewManager.ReviewManagerInstance.AddReview(yourRating);
                }
                else
                {
                    ReviewClass yourRating = new ReviewClass()
                    {
                        ID = edittingID,
                        Meal = dishName,
                        Rating = RatingType,
                        //Date = DateTime.Now
                    };
                    await ReviewManager.ReviewManagerInstance.UpdateReview(yourRating);
                }
                
            }
            catch (Exception ex)
            {
                //errorLabel.Text = ex.Message;
            }
            
            //reviewButton.Text = string.Format("Thanks! Review placed");

        }
        /*private async void ViewTimeline_Clicked(Object sender, EventArgs e)
        {

            List<ReviewClass> reviews = await ReviewManager.ReviewManagerInstance.GetReviews();

            TimelineList.ItemsSource = reviews;

        }*/
    }
}
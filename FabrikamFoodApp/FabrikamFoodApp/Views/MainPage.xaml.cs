using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FabrikamFoodApp.DataModels;
/*using com.google.android.gms.maps;
using com.google.android.gms.maps.model;
using android.app.Activity;
using android.os.Bundle;*/



namespace FabrikamFoodApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }




        async void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked",
                "OK");
            await Navigation.PushModalAsync(new Review(null));
        }

        /*async void OnChangeButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked",
                "OK");
            await Navigation.PushModalAsync(new ChangeReview());
        }*/

        /*async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReviewPage());
        }*/

        async void MapButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked",
                "OK");
            await Navigation.PushModalAsync(new MapPage());
        }

        async void ViewReviews_Clicked(object sender, EventArgs args)
        {
            List<ReviewClass> reviews = await ReviewManager.ReviewManagerInstance.GetReviews();

            ReviewsList.ItemsSource = reviews;
        }

        async void ChangeReviews_Clicked(Object sender, EventArgs e)
        {


            Button button2 = sender as Button;
            object code = button2.CommandParameter;

            Button button = (Button)sender;
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked",
                "OK");
            await Navigation.PushModalAsync(new Review((string)code));

        }

        async void DeleteReviews_Clicked(Object sender, EventArgs e)
        {


            Button button2 = sender as Button;
            object code = button2.CommandParameter;

            Button button = (Button)sender;
            await DisplayAlert("Delete this entry?",
                "Are you sure?",
                "OK");

            ReviewClass yourRating = new ReviewClass()
            {
                ID = (string)code
            };

            await ReviewManager.ReviewManagerInstance.DeleteReview(yourRating);

        }
    }
}

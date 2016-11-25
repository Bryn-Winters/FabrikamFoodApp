using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FabrikamFoodApp.DataModels;
using Microsoft.WindowsAzure.MobileServices;
using Plugin.Settings;
/*using com.google.android.gms.maps;
using com.google.android.gms.maps.model;
using android.app.Activity;
using android.os.Bundle;*/



namespace FabrikamFoodApp
{
    public partial class MainPage : ContentPage
    {

        bool authenticated = false;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            string userId = CrossSettings.Current.GetValueOrDefault("user", "");
            string token = CrossSettings.Current.GetValueOrDefault("token", "");

            if (!token.Equals("") && !userId.Equals(""))
            {
                MobileServiceUser user = new MobileServiceUser(userId);
                user.MobileServiceAuthenticationToken = token;

                ReviewManager.ReviewManagerInstance.AzureClient.CurrentUser = user;

                authenticated = true;
            }

            if (authenticated == true)
                this.loginButton.IsVisible = false;
        }

        async void loginButton_Clicked(object sender, EventArgs e)
        {
            if (App.Authenticator != null)
                authenticated = await App.Authenticator.Authenticate();

            if (authenticated == true)
            {
                this.loginButton.IsVisible = false;
                CrossSettings.Current.AddOrUpdateValue("user", ReviewManager.ReviewManagerInstance.AzureClient.CurrentUser.UserId);
                CrossSettings.Current.AddOrUpdateValue("token", ReviewManager.ReviewManagerInstance.AzureClient.CurrentUser.MobileServiceAuthenticationToken);
            }
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
            /*Button button = (Button)sender;
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked",
                "OK");*/
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
            await DisplayAlert("Edit review",
                "Are you sure?",
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Xamd.ImageCarousel.Forms.Plugin.Abstractions;
using System.Net.Http;
using MoviesApp.Models;
using Newtonsoft.Json;

namespace MoviesApp
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<FileImageSource> imageSources = new ObservableCollection<FileImageSource>();
        Movies mov = new Movies();
        private string Url = "https://localhost:44312/api/Movies/GetMoviesByTitle";
        HttpClient client = new HttpClient();
        public MainPage()
        {
            InitializeComponent();

            imageSources.Add("p2.jpg");
            imageSources.Add("p3.jpg");
            imageSources.Add("p4.jpg");

            imgSlider.Images = imageSources;
        }

        protected override async void OnAppearing()
        {
            string Content = await client.GetStringAsync(Url);
            IEnumerable<Movies> List = JsonConvert.DeserializeObject<IEnumerable<Movies>>(Content);
            ListMovies.ItemsSource = new ObservableCollection<Movies>(List);
            base.OnAppearing();
        }

        private void btn_hbo_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_netflix_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_buscar_Clicked(object sender, EventArgs e)
        {
            

        }
    }
}

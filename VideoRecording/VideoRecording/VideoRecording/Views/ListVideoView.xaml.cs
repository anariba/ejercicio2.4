using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRecording.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace VideoRecording.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListVideoView : ContentPage
    {
        public List<Video> AllVideos { get; set; }
        string pathSelectedVideo;
        public ListVideoView()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            chargeListView();
        }
        private async void chargeListView()
        {
          
            AllVideos = await App.BaseDatos.getListVideos();
            ListVideos.ItemsSource = AllVideos;
        }

        private void ListVideos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
        }

        private void UpdateSelectionData(IReadOnlyList<object> previousSelection, IReadOnlyList<object> currentSelection)
        {
            var selectedContact = currentSelection.FirstOrDefault() as Video;
            pathSelectedVideo = selectedContact.pathFile;
            Console.WriteLine(pathSelectedVideo);

        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewVideoSelected(pathSelectedVideo));
            pathSelectedVideo = null;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Forms.VideoPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoRecording.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewVideoSelected : ContentPage
    {
        public ViewVideoSelected(string pathVideo)
        {
            InitializeComponent();
            UriVideoSource uriVideoSource = new UriVideoSource() 
            {

                Uri = pathVideo

            };

            videoPlayer.Source = uriVideoSource;
        }

        private async  void CloseButton_Clicked(object sender, EventArgs e)
        {
            videoPlayer.Pause();
            await Navigation.PopAsync();

        }

        private void videoPlayer_PlayCompletion(object sender, EventArgs e)
        {

        }
    }
}
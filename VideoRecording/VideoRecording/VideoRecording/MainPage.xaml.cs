using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.Media;
using System.IO;
using SQLite;
using VideoRecording.Models;
using VideoRecording.Views;

namespace VideoRecording
{
    public partial class MainPage : ContentPage
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM02VideoApp.db3");
       
        string rutaDeVideo;

        public MainPage()
        {
            InitializeComponent();
            btnvideo.Clicked += btnvideo_Clicked;
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteAsyncConnection(dbPath);

            var video = new Video
            {
                name = txtName.Text,
                description = txtDescription.Text,
                pathFile = rutaDeVideo
            };

            var result = await App.BaseDatos.saveVideo(video);
            if (result == 1)
            {
                await DisplayAlert("Grabacion", "Video guardado correctamente", "OK");
                await Navigation.PopAsync();

            }
        }

        private async void btnvideo_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No hay camara", "No se detecta la camara.", "Ok");
                    return;
                }

                var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
                {
                    Name = "video.mp4",
                    Directory = "DefaultVideos",
                });

                if (file == null)
                    return;

                await DisplayAlert("Video grabado", "Ubicacion: " + file.Path, "OK");
                rutaDeVideo = file.Path;
                file.Dispose();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Permiso denegado", "Da permisos de cámara al dispositivo.\nError: " + ex.Message, "Ok");
            }

        }

        private async void btnViewVideos_Clicked(object sender, EventArgs e)
        {
            var ViewVideosPages = new ListVideoView();

            await Navigation.PushAsync(ViewVideosPages);
        }
    }
}

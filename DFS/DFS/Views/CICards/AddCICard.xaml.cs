using DFS.Services.Models;
using DFS.ViewModel;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DFS.Views.CICards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCICard : ContentPage
    {
        Action callBack;
        AddCardViewModel vm;
        public AddCICard()
        {
            InitializeComponent();
            callBack = new Action(ShowMessage);
           vm = new AddCardViewModel(callBack);
            BindingContext = vm;

        }
        private void ShowMessage()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                DisplayAlert("Success!", "Card created successfully", "ok");
            });
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            IGetCards service = new GetCardService();


            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });




            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");
            Stream stream = null;
            image.Source = ImageSource.FromStream(() =>
            {
                stream = file.GetStream();

                return stream;
            });
            var bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes, 0, (int)stream.Length);
            vm.Base64Image = System.Convert.ToBase64String(bytes);
        }
    }
}
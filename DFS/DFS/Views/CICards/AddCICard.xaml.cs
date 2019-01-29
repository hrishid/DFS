using DFS.ViewModel;
using Plugin.Media;
using System;
using System.Collections.Generic;
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
		public AddCICard ()
		{
			InitializeComponent ();

            BindingContext = new AddCardViewModel();
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

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }
    }
}
using DFS.Services.Models;
using DFS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DFS.Views.DisplayCard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayCardPage : ContentPage
    {
        
        public DisplayCardPage()
        {
            InitializeComponent();

            
            this.BindingContext = new DisplayCiCardViewModel();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            IGetCards cards = new GetCardService();
            CardList.ItemsSource = await cards.GetAllUserCards();          
        }
    }
}
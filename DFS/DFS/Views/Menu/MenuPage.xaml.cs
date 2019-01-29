using DFS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DFS.Views.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        RootPage root;
        List<Models.MenuItem> menuItems;
        public MenuPage(RootPage root)
        {

            this.root = root;
            InitializeComponent();
            BackgroundColor = Color.FromHex("#03A9F4");
            ListViewMenu.BackgroundColor = Color.FromHex("#F5F5F5");
            Title = "Home";
            BindingContext = new BaseViewModel
            {
                //Subtitle = App.User.FirstName + " " + App.User.LastName,
                //Title = App.User.SchoolName,
                Icon = "slideout.png"

            };
           // icon.Source = App.User.Image;

            ListViewMenu.ItemsSource = menuItems = new List<Models.MenuItem>
                {
                    new Models.MenuItem { Title = "Home", MenuType = MenuType.Home, Icon ="home.png" },
                    //new Models.MenuItem { Title = "Time Table", MenuType = MenuType.TimeTable, Icon = "Attendance.png" },
                    new Models.MenuItem { Title = "CI Cards", MenuType = MenuType.CICards, Icon = "home.png" },
                    ////new Models.MenuItem { Title = "Attendance", MenuType = MenuType.Attendance, Icon = "attendanceicon.png" },
                    new Models.MenuItem { Title = "Profile", MenuType = MenuType.Profile, Icon = "ic_account_circle_black_24dp.png" },
                     //new Models.MenuItem { Title = "Gallery", MenuType = MenuType.Gallery, Icon = "GalleryIcon.png" },
                     // new Models.MenuItem { Title = "Alerts", MenuType = MenuType.Alert, Icon = "AlertIcon.png" },
                    new Models.MenuItem { Title = "Sign Out", MenuType = MenuType.Signout, Icon = "signout.png" },
                };

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (ListViewMenu.SelectedItem == null)
                    return;
                await this.root.NavigateAsync(((Models.MenuItem)e.SelectedItem).MenuType);
            };
        }
    }
}
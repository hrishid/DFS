using DFS.Helpers;
using DFS.ViewModel;
using DFS.Views.CICards;
using DFS.Views.DisplayCard;
using DFS.Views.Menu;
using DFS.Views.Profile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DFS.Views
{
    public class RootPage : MasterDetailPage
    {
        Dictionary<MenuType, NavigationPage> Pages { get; set; }
        public RootPage()
        {

            Pages = new Dictionary<MenuType, NavigationPage>();
            Master = new MenuPage(this);
            Title = "Home";
            BindingContext = new BaseViewModel
            {
                Title = "Adani",
                Icon = "slideout.png"
            };
            //setup home page
            NavigateAsync(MenuType.Home);

            InvalidateMeasure();
        }

        public async Task NavigateAsync(MenuType id)
        {
            try
            {

                if (Detail != null)
                {
                    IsPresented = false;
                }

                Page newPage;
                if (!Pages.ContainsKey(id))
                {

                    switch (id)
                    {
                        case MenuType.Home:
                            Pages.Add(id, new CustomNavigationPage(new HomePage()));
                            break;
                        case MenuType.Profile:
                            Pages.Add(id, new CustomNavigationPage(new ProfilePage()));
                            break;
                        case MenuType.CICards:
                            Pages.Add(id, new CustomNavigationPage(new AddCICard()));
                            break;
                        //case MenuType.TimeTable:
                        //    Pages.Add(id, new CustomNavigationPage(new TimeTableView()));
                        //    break;
                        //case MenuType.Attendance:
                        //    Pages.Add(id, new CustomNavigationPage(new MonthView()));
                        //    break;
                        case MenuType.MyCards:
                            Pages.Add(id, new CustomNavigationPage(new DisplayCardPage()));
                            break;
                        //case MenuType.Alert:
                        //    Pages.Add(id, new CustomNavigationPage(new AlertsPage()));
                        //    break;
                        case MenuType.Signout:
                            Pages.Clear();
                            // DependencyService.Get<INotification>().UnRegisterNotification();
                           // App.Database.DropTable();
                            App.Current.MainPage = new MainPage();
                            break;
                    }
                }

                newPage = Pages[id];
                if (newPage == null)
                    return;

                Detail = newPage;
            }
            catch (Exception ex)
            {
            }
        }
    }
}

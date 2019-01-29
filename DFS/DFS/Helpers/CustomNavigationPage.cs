using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DFS.Helpers
{

    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage(Page root) : base(root)
        {
            Init();
        }

        public CustomNavigationPage()
        {
            Init();
        }

        void Init()
        {

            BarBackgroundColor = Color.FromHex("#03A9F4");
            BarTextColor = Color.White;
        }
    }

}

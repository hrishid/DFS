using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DFS.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(DFS.Helpers.Controls.CustomEntry), typeof(CustomEntryRenderer))]
namespace DFS.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                return;
            }

            var nativeEditTextField = (Android.Widget.EditText)this.Control;

            nativeEditTextField.SetHintTextColor(Android.Graphics.Color.White);

            const int ID = Resource.Drawable.entry_border;
            var drawable = this.Context.Resources.GetDrawable(ID);
            nativeEditTextField.SetBackgroundDrawable(drawable);
        }
    }
}
using NewJobSearch.App.UWP.Utility.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using static System.Net.Mime.MediaTypeNames;

[assembly: ExportRenderer(typeof(ImageButton), typeof(CustomImageButtonRenderer))]
namespace NewJobSearch.App.UWP.Utility.Controls
{
   public class CustomImageButtonRenderer : ImageButtonRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ImageButton> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var style = Windows.UI.Xaml.Application.Current.Resources["ImageButtonStyle"] as Windows.UI.Xaml.Style;
                Control.Style = style;
            }
        }
    }
}

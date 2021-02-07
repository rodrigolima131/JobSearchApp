using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewJobSearch.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Start : ContentPage
    {
        public Start()
        {
            InitializeComponent();
        }

        private void GoVisualizer(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Visualizer());
        }

        private void GoRegisterJob(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterJob());
        }

        private void FocusSearch(object sender, EventArgs e)
        {
            TxtPesquisa.Focus();
        }

        private void FocusCity(object sender, EventArgs e)
        {
            TxtCityState.Focus();
        }
    }
}
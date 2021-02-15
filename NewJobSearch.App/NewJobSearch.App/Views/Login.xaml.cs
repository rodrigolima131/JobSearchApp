using JobSearch.Domain.Models;
using NewJobSearch.App.Models;
using NewJobSearch.App.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NewJobSearch.App.Utility.Load;

namespace NewJobSearch.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        private UserService _service;



        public Login()
        {
            InitializeComponent();
            _service = new UserService();
        }

        private void GoRegister(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }

        private async void GoStart(object sender, EventArgs e)
        {
            string email = TxtEmail.Text;
            string password = TxtPassword.Text;
            //TODO ajuste email e senha ToString().ToLower()
            await Navigation.PushPopupAsync(new Loading());
           ResponseService<User> responseService = await _service.GetUser(email, password);

            if (responseService.IsSuccess)
            {

                JsonConvert.SerializeObject(responseService);
                App.Current.Properties.Add("User", JsonConvert.SerializeObject(responseService.Data));
                await App.Current.SavePropertiesAsync();
                App.Current.MainPage = new NavigationPage(new Start());
            }
            else
            {
                if (responseService.StatusCode == 404)
                {
                    await DisplayAlert("Atenção", "Nenhum Usuario encontrado!", "Ok");
                }
                else
                {
                    await DisplayAlert("Atenção", "Oops! Ocorreu um erro inesperado! Tente novamente mais tarde", "Ok");
                }
            }
            await Navigation.PopAllPopupAsync();
        }
    }
}
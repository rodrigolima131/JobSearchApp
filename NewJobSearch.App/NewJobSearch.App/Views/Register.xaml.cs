using JobSearch.Domain.Models;
using NewJobSearch.App.Models;
using NewJobSearch.App.Services;
using NewJobSearch.App.Utility.Load;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
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
    public partial class Register : ContentPage
    {
        private UserService _service;

        public Register()
        {
            InitializeComponent();
            _service = new UserService();
        }

        private void GoBack(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void SaveAction(object sender, EventArgs e)
        {
            TxtMessages.Text = String.Empty;
            string email = TxtEmail.Text;
            string password = TxtPassword.Text;
            string name = TxtName.Text;

            if (email == null) email = "";
            if (password == null) password = "";
            if (name == null) name = "";

            //TODO ajuste email e senha ToString().ToLower()
     

            User user = new User() { Name = name, Email = email, Password = password };
            
            await Navigation.PushPopupAsync(new Loading());
            ResponseService<User> responseService = await _service.AddUser(user);


            if (responseService.IsSuccess)
            {
                App.Current.Properties.Add("User", JsonConvert.SerializeObject(responseService.Data));
                await App.Current.SavePropertiesAsync();
                App.Current.MainPage = new NavigationPage(new Start());
            }
            else
            {
                
                if (responseService.StatusCode == 400)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach(var dicKey in responseService.Errors)
                    {
                        foreach(var message in dicKey.Value)
                        {
                            sb.AppendLine(message);

                        }

                    }

                    TxtMessages.Text = sb.ToString();

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
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileAppProject
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            
        }

        async void AddTermSheet(object sender, EventArgs arg)
        {
            NavigationPage at = new NavigationPage(new AddTerm());
            await Navigation.PushModalAsync(new NavigationPage(new AddTerm()));
        }
    }
}

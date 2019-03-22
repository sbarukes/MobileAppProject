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
        List<DBTerm> terms;

        public MainPage()
        {
            InitializeComponent();
            
        }

        async void AddTermSheet(object sender, EventArgs arg)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddTerm()));
        }

        public void RetrieveCreateDB()
        {
            DataHelper dh = new DataHelper();
            bool exists = dh.createDB();

            if (exists)
            {
                terms = dh.SelectTerms();
            }

            list.ItemsSource = terms;

        }

        private void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedTerm = list.SelectedItem as DBTerm;

            if (selectedTerm != null)
            {
                Navigation.PushModalAsync(new EditTerm(selectedTerm));
            }
        }
    }
}

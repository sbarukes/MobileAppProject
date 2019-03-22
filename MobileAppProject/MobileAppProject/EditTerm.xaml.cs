using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditTerm : ContentPage
	{
        DBTerm selectedTerm;
        DataHelper dh = new DataHelper();

		public EditTerm (DBTerm selectedTerm)
		{
			InitializeComponent ();
            this.selectedTerm = selectedTerm;
		}

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            termtitle.Text = selectedTerm.title;
            termstart.Date = selectedTerm.start;
            termend.Date = selectedTerm.end;

            List<DBCourse> relatedCourses = dh.SelectCourses(selectedTerm.termid);
            list.ItemsSource = relatedCourses;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            selectedTerm.title = termtitle.Text;
            selectedTerm.start = termstart.Date;
            selectedTerm.end = termend.Date;
            dh.UpdateTerm(selectedTerm);
            Navigation.PopModalAsync();
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            dh.DeleteTerm(selectedTerm);
            Navigation.PopModalAsync();
        }

        async public void AddCourseSheet(object sender, EventArgs arg)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddCourse(selectedTerm.termid)));
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace MobileAppProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditCourse : ContentPage
	{
        DataHelper dh = new DataHelper();
        DBCourse selectedCourse;
		public EditCourse (DBCourse selectedCourse)
		{
			InitializeComponent ();
            this.selectedCourse = selectedCourse;
		}

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            editcourse.Text = selectedCourse.coursetitle;
            edittypepicker.SelectedItem = selectedCourse.status;
            courseeditstart.Date = selectedCourse.coursestartdate;
            courseeditend.Date = selectedCourse.courseenddate;
            editcoursenotes.Text = selectedCourse.notes;
            editcoursename.Text = selectedCourse.instructorname;
            editcourseemail.Text = selectedCourse.instructoremail;
            editcoursephone.Text = selectedCourse.instructorphonenumber;

            List<DBAssesment> relatedAssesments = dh.SelectAssesments(selectedCourse.courseid);
            list.ItemsSource = relatedAssesments;
        }

        //Notes Sharing
        private async void sharenotes_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = editcoursenotes.Text,
                Title = "Notes"
            });
        }

        private void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedAssesment = list.SelectedItem as DBAssesment;

            if (selectedAssesment != null)
            {
                Navigation.PushModalAsync(new EditAssesment(selectedAssesment));
            }
        }

        async private void AssesmentButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddAssesment(selectedCourse.courseid)));
        }

        private void Button_Clicked_Save(object sender, EventArgs e)
        {
            if ((editcoursephone.Text != "" && editcoursename.Text != "" && editcourseemail.Text != "") && (courseeditstart.Date <= courseeditend.Date))
            {
                selectedCourse.coursetitle = editcourse.Text;
                selectedCourse.status = edittypepicker.SelectedItem.ToString();
                selectedCourse.coursestartdate = courseeditstart.Date;
                selectedCourse.courseenddate = courseeditend.Date;
                selectedCourse.instructorname = editcoursename.Text;
                selectedCourse.instructoremail = editcourseemail.Text;
                selectedCourse.instructorphonenumber = editcoursephone.Text;

                dh.UpdateCourse(selectedCourse);
                Navigation.PopModalAsync();
            }
            else
            {
                DisplayAlert("Alert", "Make sure Instructor Information is filled out and the stard date is before the end date!", "Ok");
            }
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            dh.DeleteCourse(selectedCourse);
            Navigation.PopModalAsync();
        }

    }
}
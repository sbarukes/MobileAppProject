using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.LocalNotifications;

namespace MobileAppProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCourse : ContentPage
	{
        DBCourse course = new DBCourse();
        DataHelper dh = new DataHelper();
		public AddCourse (int relatedTermId)
		{
			InitializeComponent ();
            course.termid = relatedTermId;
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            if ((addcoursephone.Text != null && addcoursename.Text != null && addcourseemail.Text != null) && (courseaddstart.Date <= courseaddend.Date)) {
                course.coursetitle = addcourse.Text;
                course.coursestartdate = courseaddstart.Date;
                course.courseenddate = courseaddend.Date;
                course.notes = addcoursenotes.Text;
                course.status = addtypepicker.SelectedItem.ToString();
                course.instructorname = addcoursename.Text;
                course.instructoremail = addcourseemail.Text;
                course.instructorphonenumber = addcoursephone.Text;

                dh.InsertIntoCourse(course);
                Navigation.PopModalAsync();

                //Course Notification Set
                if(addnotificationpicker.SelectedItem.ToString() == "Yes")
                {
                    CrossLocalNotifications.Current.Show("Course Start", $"{addcourse.Text} starts today!", 1, courseaddstart.Date);
                    CrossLocalNotifications.Current.Show("Course End", $"{addcourse.Text} ends today!", 2, courseaddend.Date);
                }
            }
            else
            {
                DisplayAlert("Alert", "Make sure Instructor Information is filled out and the stard date is before the end date!", "Ok");
            }
        }

        //Notes Sharing
        private async void sharenotes_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = addcoursenotes.Text,
                Title = "Notes"
            });
        }
    }
}
using Plugin.LocalNotifications;
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
	public partial class AddAssesment : ContentPage
	{
        DBAssesment assesment = new DBAssesment();
        DataHelper dh = new DataHelper();

        public AddAssesment (int relatedCourseID)
		{
			InitializeComponent ();
            assesment.courseid = relatedCourseID;
		}

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            assesment.assesmentname = addassesmentname.Text;
            assesment.type = addassesmenttype.SelectedItem.ToString();
            assesment.assesmentdate = assesmentdate.Date;
            dh.InsertIntoAssesment(assesment);
            Navigation.PopModalAsync();

            //Assesment Notification Set
            if (addnotificationpicker.SelectedItem.ToString() == "Yes")
            {
                CrossLocalNotifications.Current.Show("Assesment", $"{addassesmentname.Text} is today!", 3, assesmentdate.Date);
            }
        }
    }
}
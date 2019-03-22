﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            if (addcoursephone.Text != null && addcoursename.Text != null && addcourseemail != null) {
                course.coursetitle = addcourse.Text;
                course.coursestartdate = courseaddstart.Date;
                course.courseenddate = courseaddend.Date;
                course.status = addtypepicker.SelectedItem.ToString();
                course.instructorname = addcoursename.Text;
                course.instructoremail = addcourseemail.Text;
                course.instructorphonenumber = addcoursephone.Text;

                dh.InsertIntoCourse(course);
                Navigation.PopModalAsync();
            }
            else
            {
                DisplayAlert("Alert", "Make sure Instructor Information is filled out!", "Ok");
            }
        }
    }
}
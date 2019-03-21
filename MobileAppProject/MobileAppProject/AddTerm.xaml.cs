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
	public partial class AddTerm : ContentPage
	{
		public AddTerm ()
		{
			InitializeComponent ();
		}

        async public void AddCourseSheet(object sender, EventArgs arg)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddCourse()));
        }
	}
}
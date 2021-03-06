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

        public void AddTermNew(object sender, EventArgs arg)
        {
            if (termstart.Date <= termend.Date)
            {
                DBTerm term = new DBTerm();
                term.title = termtitle.Text;
                term.start = termstart.Date;
                term.end = termend.Date;

                DataHelper dh = new DataHelper();
                dh.InsertIntoTerm(term);

                Navigation.PopModalAsync();
            }
            else
            {
                DisplayAlert("Alert!", "Make sure the start date is before the end date.", "Ok");
            }
        }
        
    }
}
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
	public partial class EditAssesment : ContentPage
	{
        DataHelper dh = new DataHelper();
        DBAssesment selectedAssesment;

        public EditAssesment (DBAssesment selectedAssesment)
		{
			InitializeComponent ();
            this.selectedAssesment = selectedAssesment;
		}

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            editassesmenttype.SelectedItem = selectedAssesment.type;
            editassesmentname.Text = selectedAssesment.assesmentname;
            assesmentdate.Date = selectedAssesment.assesmentdate;

        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            selectedAssesment.type = editassesmenttype.SelectedItem.ToString();
            selectedAssesment.assesmentname = editassesmentname.Text;
            selectedAssesment.assesmentdate = assesmentdate.Date;

            dh.UpdateAssesment(selectedAssesment);
            Navigation.PopModalAsync();
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            dh.DeleteAssesment(selectedAssesment);
            Navigation.PopModalAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFirebase.Services;

namespace XamarinFirebase
{

    //https://www.c-sharpcorner.com/article/xamarin-forms-working-with-firebase-realtime-database-crud-operations/
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        readonly Helper h = new Helper();
        readonly Firebase f = new Firebase();
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var allPersons = await h.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }     

        private async void BtnRetrieve_Clicked(object sender, EventArgs e)
        {
            var person = await h.GetPerson(Convert.ToInt32(txtId.Text));

            if (person!=null)
            {
                txtId.Text = person.PersonId.ToString();
                txtName.Text = person.Name;
                await DisplayAlert("Success", "Person found!", "Ok");
            }
            else
            {
                await DisplayAlert("Not a success", "Person not there", "Ok");
            }
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await h.AddPerson(Convert.ToInt32(txtId.Text), txtName.Text);
            ResetFields("added");
            
        }
        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            await h.UpdatePerson(Convert.ToInt32(txtId.Text), txtName.Text);
            ResetFields("updated");
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            await h.DeletePerson(Convert.ToInt32(txtId.Text));
            ResetFields("deleted");
        }

        private async void ResetFields(string text)
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;

            await DisplayAlert("Success", "Person "+text+" successfully", "Ok");
            lstPersons.ItemsSource = await h.GetAllPersons();
        }
    }
}

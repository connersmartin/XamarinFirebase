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
            var a = await f.GetData();
        }

        private  void BtnAdd_Clicked(object sender, EventArgs e)
        {

            var b = f.AddData(new Dictionary<string, object>()
            {
                {"ID", 3 },
                {"Name", "What" }
            });
        }

        private  void BtnDelete_Clicked(object sender, EventArgs e)
        {
        }
        private  void BtnUpdate_Clicked(object sender, EventArgs e)
        {
        }
    }
}

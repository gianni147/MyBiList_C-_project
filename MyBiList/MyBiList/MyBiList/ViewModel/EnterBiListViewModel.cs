using System;
using System.Collections.Generic;
using System.Text;
using MyBiList.Model;
using MyBiList.Service;
using Xamarin.Forms;

namespace MyBiList.ViewModel
{
    public class EnterBiListViewModel
    {
        public int ID { get; set; }

        public String Name { get; set; }
        public String Date { get; set; }
        public String Idea { get; set; }

        BiList _bilist;

        public Command SaveCommand { get; set; }

        public EnterBiListViewModel()
        {
            SaveCommand = new Command(EnterBiListMethod);
        }

        public EnterBiListViewModel(BiList bilist)
        {
            _bilist = bilist;
            SaveCommand = new Command(EditTodoMethod);
            ID = bilist.ID;
            Name = bilist.Name.ToString();
            Date = bilist.Date.ToString();
            Idea = bilist.Idea.ToString();

        }

        public IDataStore DataStore => DependencyService.Get<IDataStore>();


        public async void EnterBiListMethod()
        {

            try
            {
                if (Name == null)
                {
                    Name = "NoName";
                }
                if (Date == null)
                {
                    Date = "12-27-2001";
                }
                if (Idea == null)
                {
                    Idea = " ";
                }
                await DataStore.AddBiList(new BiList() {ID = ID, Name = Name, Date = Date, Idea = Idea });
                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Error", "Invalid Urgency", "Ok");
            }

        }

        public async void EditTodoMethod()
        {
            
            try
            {

                await DataStore.UpdateBiList(new BiList() { ID = ID, Name = Name, Date = Date, Idea = Idea });

                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Error", "Invalid Urgency", "Ok");
            }

        }




    }
}

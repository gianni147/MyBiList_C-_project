using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using MyBiList.Model;
using MyBiList.Service;
using Xamarin.Forms;

namespace MyBiList.ViewModel
{
    internal class MainViewmodel : INotifyPropertyChanged
    {
        String _name;
        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropertyChangedMethod();
            }
        }

        public Command AddCommand { get; set; }
        public Command EditCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command RefreshCommand { get; set; }
        public BiList SelectedBiList { get; set; }

        public ObservableCollection<BiList> BiList { get; set; } = new ObservableCollection<BiList>();

        public IDataStore DataStore => DependencyService.Get<IDataStore>();


        public MainViewmodel()
        {
            Name = "Hello from this";

            AddCommand = new Command(AddMethod);
            EditCommand = new Command(EditMethod);
            DeleteCommand = new Command(DeleteMethod);
            RefreshCommand = new Command(RefreshMethod);
            FillbiList();

        }

        public void AddMethod()
        {
            App.Current.MainPage.Navigation.PushAsync(new EnterBiListView());
        }



        public async void EditMethod()
        {
            if (SelectedBiList != null)
            {
                bool answer = await App.Current.MainPage.DisplayAlert("Edit", $"Wil je de gegevens van {SelectedBiList.Name} bewerken?", "Yes", "No");
                {
                    if (answer)
                    {
                        await App.Current.MainPage.Navigation.PushAsync(new EnterBiListView(SelectedBiList));

                    }
                }
            }

        }


        public async void DeleteMethod()
        {
            if (SelectedBiList != null)
            {
                bool answer = await App.Current.MainPage.DisplayAlert("Delete", $"Delete {SelectedBiList.Name}?", "Yes", "No");
                if (answer)
                {
                    await DataStore.DeleteBiList(SelectedBiList);
                    RefreshMethod();
                }
            }

        }

        public async void FillbiList()
        {
            BiList.Clear();
            var bilists = await DataStore.GetAllBiList();
            foreach (BiList t in bilists)
            {
                BiList.Add(t);
            }
        }

        public void RefreshMethod()
        {
            FillbiList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void PropertyChangedMethod([CallerMemberName] String propname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

    }
}

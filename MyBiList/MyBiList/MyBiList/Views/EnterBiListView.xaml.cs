using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBiList.Model;
using MyBiList.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MyBiList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterBiListView : ContentPage
    {
        EnterBiListViewModel vm;

        public EnterBiListView()
        {
            InitializeComponent();

            BindingContext = vm = new EnterBiListViewModel();
           
        }
        public EnterBiListView(BiList bilist)
        {
            InitializeComponent();

            BindingContext = vm = new EnterBiListViewModel(bilist);
        }

    }
}
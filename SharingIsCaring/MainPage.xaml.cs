using System.Windows.Input;
using SharingIsCaring.Dependencies;
using SharingIsCaring.ViewModels;
using Xamarin.Forms;

namespace SharingIsCaring
{
    public partial class MainPage : ContentPage
    {

        MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            
            viewModel = new MainPageViewModel();
            BindingContext = viewModel;
        }
       
    }
}

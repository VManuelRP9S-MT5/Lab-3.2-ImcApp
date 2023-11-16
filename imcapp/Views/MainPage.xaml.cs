using Microsoft.Maui.Controls;
using imcapp.ViewModels; 
namespace imcapp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}

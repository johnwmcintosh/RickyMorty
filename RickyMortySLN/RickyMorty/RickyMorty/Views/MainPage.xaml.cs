using RickyMorty.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RickyMorty.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var vm = new MainViewModel(Navigation);

            BindingContext = vm;

            _ = Task.Run(async () => await vm.Init());
        }

        private void NativeEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var vm = (MainViewModel)BindingContext;
            vm.Filter(e.NewTextValue);
        }
    }
}
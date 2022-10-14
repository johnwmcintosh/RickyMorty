using RickyMorty.Models;
using RickyMorty.ViewModels;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RickyMorty.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {
        public Detail(Location location)
        {
            InitializeComponent();

            var vm = new DetailViewModel(Navigation);
            BindingContext = vm;

            _ = Task.Run(async () => await vm.Init(location));
        }
    }
}
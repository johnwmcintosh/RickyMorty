using RickyMorty.Core;
using RickyMorty.Models;
using RickyMorty.Services;
using RickyMorty.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RickyMorty.ViewModels
{
    public class MainViewModel : Notify
    {
        public MainViewModel(INavigation navigation)
        {
            Navigation = navigation;
            SortAscCommand = new Command(SortAsc);
            SortDescCommand = new Command(SortDesc);
        }

        public INavigation Navigation { get; set; }

        private string loadingText;
        public string LoadingText { get => loadingText; set { loadingText = value; RaisePropertyChanged(); } }

        private ObservableCollection<Location> locations;
        public ObservableCollection<Location> Locations { get => locations; set { locations = value; RaisePropertyChanged(); } }

        private List<Location> allLocations = new List<Location>();

        public Command<Location> NavToDetailCommand { get; set; }

        public Command SortAscCommand { get; set; }
        public Command SortDescCommand { get; set; }

        public async Task Init()
        {
            IsBusy = true;
            LoadingText = "Loading";

            NavToDetailCommand = new Command<Location>(async (l) => await SeeDetail(l));

            allLocations = await ApiService.GetAllLocationsAsync();
            Locations = new ObservableCollection<Location>(allLocations);
            
            IsBusy = false;
        }

        public void Filter(string text)
        {
            Locations.Clear();
            if (text == string.Empty)
                Locations = new ObservableCollection<Location>(allLocations);
            else
                Locations = new ObservableCollection<Location>(allLocations.Where(t => t.Name.ToLower().Contains(text.ToLower())));
        }

        private void SortAsc()
        {
            Locations = new ObservableCollection<Location>(Locations.OrderBy(t => t.Name));
        }

        private void SortDesc()
        {
            Locations = new ObservableCollection<Location>(Locations.OrderByDescending(t => t.Name));
        }

        public async Task SeeDetail(Location loc)
        {
            var detailPage = new Detail(loc);

            await Navigation.PushAsync(detailPage);
        }
    }
}

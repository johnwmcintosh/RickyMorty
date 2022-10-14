using RickyMorty.Models;
using RickyMorty.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RickyMorty.ViewModels
{
    public class MainViewModel : Notify
    {
        public MainViewModel()
        {

        }

        private string loadingText;
        public string LoadingText { get => loadingText; set { loadingText = value; RaisePropertyChanged(); } }

        private ObservableCollection<Location> locations;
        public ObservableCollection<Location> Locations { get => locations; set { locations = value; RaisePropertyChanged(); } }

        public async Task Init()
        {
            IsBusy = true;
            LoadingText = "Loading";

            Locations = new ObservableCollection<Location>();

            foreach (var loc in await ApiService.GetAllLocationsAsync())
            {
                LoadingText = "Loading";
                foreach (Uri resident in loc.Residents)
                {
                    LoadingText += ".";
                    loc.Characters.Add(await ApiService.GetCharacterByUriAsync(resident));
                }

                LoadingText = "Loading";
                Locations.Add(loc);
            }

            IsBusy = false;
        }
    }
}

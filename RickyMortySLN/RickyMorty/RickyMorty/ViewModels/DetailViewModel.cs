using RickyMorty.Models;
using RickyMorty.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RickyMorty.ViewModels
{
    public class DetailViewModel : Notify
    {
        public INavigation Navigation { get; private set; }

        private Location location;
        public Location Location { get => location; private set { location = value; RaisePropertyChanged(); } }

        public DetailViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        private ObservableCollection<Character> characters;
        public ObservableCollection<Character> Characters { get => characters; set { characters = value; RaisePropertyChanged(); } }

        public async Task Init(Location location)
        {
            string Ids = string.Empty;

            Characters = new ObservableCollection<Character>();

            Location = location;

            foreach (Uri resident in location.Residents)
            {
                // strip out the id
                var id = resident.AbsoluteUri.Replace($"{ApiService.baseApi}character/", string.Empty);
                Ids += $"{id},";
            }

            foreach(var character in await ApiService.GetCharacterGroup(Ids))
            {
                Characters.Add(character);
            }
        }

    }
}

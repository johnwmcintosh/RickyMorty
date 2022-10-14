using Newtonsoft.Json;
using RickyMorty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickyMorty.Services
{

    public static class ApiService
    {
        public const string baseApi = "https://rickandmortyapi.com/api/";

        private static List<Location> Locations { get; set; } = new List<Location>();
        private static List<Character> Characters { get; set; } = new List<Character>();

        private static async Task<T> BasicGet<T>(string endpoint, int page, string query = "") where T : class
        {
            string api = $"{baseApi}{endpoint}/?page={page}{query}";

            var json = await (await HttpService.RequestAsync(api, HttpService.RequestType.Get)).Content.ReadAsStringAsync();

            RickyMortyWrapper<T> data = JsonConvert.DeserializeObject<RickyMortyWrapper<T>>(json);

            return data.Results;
        }

        private static async Task<T> BasicGet<T>(Uri uri)
        {
            var json = await (await HttpService.RequestAsync(uri.AbsoluteUri, HttpService.RequestType.Get)).Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(json);

            return data;
        }

        private static async Task<T> BasicGetNoPageNoWrapper<T>(string endpoint) where T : class
        {
            string api = $"{baseApi}{endpoint}";

            var json = await (await HttpService.RequestAsync(api, HttpService.RequestType.Get)).Content.ReadAsStringAsync();

            T data = JsonConvert.DeserializeObject<T>(json);

            return data;
        }

        public static async Task<List<Location>> GetAllLocationsAsync(int page = 1)
        {
            var locations = await BasicGet<List<Location>>("location", page);
            var orderedLocations = locations.OrderBy(t => t.Name);
            Locations.AddRange(orderedLocations);
            return locations;
        }

        public static async Task<List<Character>> GetCharacterGroup(string Ids)
        {
            string endpoint = $"character/{Ids}";
            var data = await BasicGetNoPageNoWrapper<List<Character>>(endpoint);

            return data;
        }

        public static async Task<Character> GetCharacterByUriAsync(Uri Uri)
        {
            var c = Characters.FirstOrDefault(t => t.Url == Uri);
            if (c == null)
            {
                c = await BasicGet<Character>(Uri);
                Characters.Add(c);
            }

            return c;
        }

        public static async Task<Character> GetCharacterAsync(int page = 1, string name = null, Status status = default, string species = null, string type = null, Gender gender = default)
        {
            string filter = string.Empty;

            if (name != null)
                filter += $"&name={name}";

            if (status != default)
                filter += $"&status={status}";

            if (species != null)
                filter += $"&species={species}";

            if (type != null)
                filter += $"&type={type}";

            if (gender != default)
                filter += $"gender={gender}";

            return await BasicGet<Character>("character", page, filter);
        }
    }

    public enum Status
    {
        /// <summary>
        /// The character is Alive
        /// </summary>
        alive,
        /// <summary>
        /// The character is dead
        /// </summary>
        dead,
        /// <summary>
        /// The character is not known to be dead or alive
        /// </summary>
        unknown
    }

    public enum Gender
    {
        /// <summary>
        /// The character is a female
        /// </summary>
        female,
        /// <summary>
        /// The character is a male
        /// </summary>
        male,
        /// <summary>
        /// The character is neither a male or female
        /// </summary>
        genderless,
        /// <summary>
        /// It is not known what gender this character is.
        /// </summary>
        uknown
    }
}

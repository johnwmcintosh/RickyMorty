using RickyMorty.Models;

namespace RickyMorty.Services
{
    public class RickyMortyWrapper<T> where T : class
    {
        public Info Info { get; set; }

        public T Results { get; set; }
    }
}

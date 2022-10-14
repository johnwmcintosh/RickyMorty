using System;

namespace RickyMorty.Models
{
    public class CharacterLocation
    {
        /// <summary>
        /// Gets name to the character's last known location.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets link to the character's last known location.
        /// </summary>
        public Uri Url { get; set; }
    }
}

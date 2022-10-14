using System;

namespace RickyMorty.Models
{
    public class CharacterOrigin
    {
        /// <summary>
        /// Gets name to the character's origin location.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets link to the character's origin location.
        /// </summary>
        public Uri Url { get; set; }
    }
}

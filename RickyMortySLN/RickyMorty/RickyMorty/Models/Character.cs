using RickyMorty.Models.Enums;
using System;
using System.Collections.Generic;

namespace RickyMorty.Models
{
    public class Character : Notify
    {
        /// <summary>
        /// Gets the id of the character.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets the name of the character.
        /// </summary>
        private string name;
        public string Name { get => name; set { name = value; RaisePropertyChanged(); } }

        /// <summary>
        /// Gets the status of the character ('Alive', 'Dead' or 'unknown').
        /// </summary>
        public CharacterStatus Status { get; set; }

        /// <summary>
        /// Gets the species of the character.
        /// </summary>
        public string Species { get; set; }

        /// <summary>
        /// Gets the type or subspecies of the character.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets the gender of the character ('Female', 'Male', 'Genderless' or 'unknown').
        /// </summary>
        public CharacterGender Gender { get; set; }

        /// <summary>
        /// Gets name and link to the character's last known location endpoint.
        /// </summary>
        public CharacterLocation Location { get; set; }

        /// <summary>
        /// Gets name and link to the character's origin location.
        /// </summary>
        public CharacterOrigin Origin { get; set; }

        /// <summary>
        /// Gets link to the character's image. All images are 300x300px and most are medium shots or portraits since they are intended to be used as avatars.
        /// </summary>
        public Uri Image { get; set; }

        /// <summary>
        /// Gets list of episodes in which this character appeared.
        /// </summary>
        public IEnumerable<Uri> Episode { get; set; }

        /// <summary>
        /// Gets link to the character's own URL endpoint.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Gets time at which the character was created in the database.
        /// </summary>
        public DateTime? Created { get; set; }
    }
}

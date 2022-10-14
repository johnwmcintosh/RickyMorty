using System;
using System.Collections.Generic;

namespace RickyMorty.Models
{
    public class Location
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets the name of the location.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the type of the location.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets the dimension in which the location is located.
        /// </summary>
        public string Dimension { get; set; }

        /// <summary>
        /// Gets list of character who have been last seen in the location.
        /// </summary>
        public List<Uri> Residents { get; set; }

        public List<Character> Characters { get; set; } = new List<Character>();

        /// <summary>
        /// Gets link to the location's own endpoint.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Gets time at which the location was created in the database. 
        /// </summary>
        public DateTime? Created { get; set; }
    }
}

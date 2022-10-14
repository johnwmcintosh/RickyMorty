using System;
using System.Collections.Generic;

namespace RickyMorty.Models
{
    public class Episode
    {
        /// <summary>
        /// Gets the id of the episode.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets the name of the episode.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the air date of the episode.
        /// </summary>
        public DateTime? AirDate { get; set; }

        /// <summary>
        ///	Gets the code of the episode. 
        /// </summary>
        public string EpisodeCode { get; set; }

        /// <summary>
        /// Gets list of characters who have been seen in the episode.
        /// </summary>
        public List<Uri> Characters { get; set; }

        /// <summary>
        /// Gets link to the episode's own endpoint.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Gets time at which the episode was created in the database.
        /// </summary>
        public DateTime? Created { get; set; }
    }
}

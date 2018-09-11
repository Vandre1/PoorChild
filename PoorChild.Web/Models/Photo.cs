namespace PoorChild.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The photo.
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the photo data.
        /// </summary>
        public PhotoData PhotoData { get; set; }
    }
}
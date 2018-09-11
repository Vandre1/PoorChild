namespace PoorChild.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The comment.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date time created.
        /// </summary>
        public DateTime? DateTimeCreated { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the photos.
        /// </summary>
        public ICollection<Photo> Photos { get; set; }

        /// <summary>
        /// Gets or sets the sender device.
        /// </summary>
        public Device SenderDevice { get; set; }
    }
}
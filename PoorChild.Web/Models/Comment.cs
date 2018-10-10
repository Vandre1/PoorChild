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
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the date time created.
        /// </summary>
        public virtual DateTime? DateTimeCreated { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public virtual string Message { get; set; }

        /// <summary>
        /// Gets or sets the photos.
        /// </summary>
        public virtual ICollection<Photo> Photos { get; set; }

        /// <summary>
        /// Gets or sets the sender device.
        /// </summary>
        public virtual Device SenderDevice { get; set; }
    }
}
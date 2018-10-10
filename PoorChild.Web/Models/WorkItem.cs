namespace PoorChild.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The work item.
    /// </summary>
    public class WorkItem
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the date time item completed.
        /// </summary>
        public virtual DateTime? DateTimeItemCompleted { get; set; }

        /// <summary>
        /// Gets or sets the date time item complete comfirmed.
        /// </summary>
        public virtual DateTime? DateTimeItemCompleteConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the date time item created.
        /// </summary>
        public virtual DateTime DateTimeItemCreated { get; set; }

        /// <summary>
        /// Gets or sets the child device.
        /// </summary>
        public virtual ChildDevice ChildDevice { get; set; }

        /// <summary>
        /// Gets or sets the parent device.
        /// </summary>
        public virtual ParentDevice ParentDevice { get; set; }

        /// <summary>
        /// Gets or sets the photos.
        /// </summary>
        public virtual ICollection<Photo> Photos { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
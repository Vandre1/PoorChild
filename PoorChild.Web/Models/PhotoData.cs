namespace PoorChild.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The photo data.
    /// </summary>
    public class PhotoData
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public virtual byte[] Data { get; set; }
    }
}
namespace PoorChild.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    using Newtonsoft.Json;

    /// <summary>
    /// The photo.
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        [NotMapped]
        public virtual string Url => $"http://{HttpContext.Current.Request.Url.Authority}/PoorChild.Web/api/photos/{this.Id}";

        /// <summary>
        /// Gets or sets the photo data.
        /// </summary>
        [JsonIgnore]
        public virtual PhotoData PhotoData { get; set; }
    }
}
namespace PoorChild.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The device.
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the android id.
        /// </summary>
        [Required]
        public virtual string AndroidId { get; set; }

        /// <summary>
        /// Gets or sets the date time device registered.
        /// </summary>
        public virtual DateTime DateTimeDeviceRegisteredInUtc { get; set; }
    }
}
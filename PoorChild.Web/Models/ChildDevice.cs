namespace PoorChild.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The child device.
    /// </summary>
    public class ChildDevice : Device
    {
        /// <summary>
        /// Gets or sets the device key for link child device to parent device.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int DeviceKey { get; set; }

        /// <summary>
        /// Gets or sets the parent device.
        /// </summary>
        public virtual ParentDevice ParentDevice { get; set; }
    }
}
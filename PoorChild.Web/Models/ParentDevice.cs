namespace PoorChild.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The parent device.
    /// </summary>
    public class ParentDevice : Device
    {
        /// <summary>
        /// Gets or sets the child devices.
        /// </summary>
        public virtual ICollection<ChildDevice> ChildDevices { get; set; }
    }
}
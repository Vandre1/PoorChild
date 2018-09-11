namespace PoorChild.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using PoorChild.Web.Models;

    /// <summary>
    /// The child devices controller.
    /// </summary>
    public class ChildDevicesController : ApiController
    {
        /// <summary>
        /// The dataContext.
        /// </summary>
        private DataContext dataContext = new DataContext();

        /// <summary>
        /// GET: api/ChildDevices
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<ChildDevice> GetChildDevices()
        {
            return this.dataContext.Devices.OfType<ChildDevice>();
        }

        /// <summary>
        /// GET: api/ChildDevices/5
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [ResponseType(typeof(ChildDevice))]
        public async Task<IHttpActionResult> GetChildDevices(Guid id)
        {
            var childDevices = await this.dataContext.Devices.OfType<ChildDevice>().Where(c => c.ParentDevice != null && c.ParentDevice.Id == id).ToListAsync();
            return this.Ok(childDevices);
        }

        /// <summary>
        /// POST: api/ChildDevices
        /// </summary>
        /// <param name="childDevice">
        /// The child device.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [ResponseType(typeof(ChildDevice))]
        public async Task<IHttpActionResult> PostChildDevice(ChildDevice childDevice)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.ChildDeviceExists(childDevice.AndroidId))
            {
                childDevice = this.dataContext.Devices.OfType<ChildDevice>().Single(e => e.AndroidId == childDevice.AndroidId);
                return this.CreatedAtRoute("DefaultApi", new { id = childDevice.Id }, childDevice);
            }

            childDevice.DateTimeDeviceRegisteredInUtc = DateTime.UtcNow;

            this.dataContext.Devices.Add(childDevice);
            await this.dataContext.SaveChangesAsync();

            return this.CreatedAtRoute("DefaultApi", new { id = childDevice.Id }, childDevice);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.dataContext.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// The child device exists.
        /// </summary>
        /// <param name="androidId">
        /// The androidId.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool ChildDeviceExists(string androidId)
        {
            return this.dataContext.Devices.Any(e => e.AndroidId == androidId);
        }
    }
}
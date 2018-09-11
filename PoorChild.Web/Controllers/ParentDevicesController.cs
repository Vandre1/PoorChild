using System;
using System.Collections.Generic;
using System.Data;
namespace PoorChild.Web.Controllers
{
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
    /// The parent devices controller.
    /// </summary>
    public class ParentDevicesController : ApiController
    {
        /// <summary>
        /// The dataContext.
        /// </summary>
        private DataContext dataContext = new DataContext();

        /// <summary>
        /// GET: api/ParentDevices
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<ParentDevice> GetParentDevices()
        {
            return this.dataContext.Devices.OfType<ParentDevice>();
        }

        /// <summary>
        /// GET: api/ParentDevices/5
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [ResponseType(typeof(ParentDevice))]
        public async Task<IHttpActionResult> GetParentDevice(Guid id)
        {
            ParentDevice parentDevice = await this.dataContext.Devices.OfType<ParentDevice>().SingleAsync(d => d.Id == id);
            if (parentDevice == null)
            {
                return this.NotFound();
            }

            return this.Ok(parentDevice);
        }

        /// <summary>
        /// POST: api/ParentDevices
        /// </summary>
        /// <param name="parentDevice">
        /// The parent device.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [ResponseType(typeof(ParentDevice))]
        public async Task<IHttpActionResult> PostParentDevice(ParentDevice parentDevice)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.ParentDeviceExists(parentDevice.AndroidId))
            {
                parentDevice = this.dataContext.Devices.OfType<ParentDevice>().Single(e => e.AndroidId == parentDevice.AndroidId);
                return this.CreatedAtRoute("DefaultApi", new { id = parentDevice.Id }, parentDevice);
            }

            parentDevice.DateTimeDeviceRegisteredInUtc = DateTime.UtcNow;

            this.dataContext.Devices.Add(parentDevice);
            await this.dataContext.SaveChangesAsync();

            return this.CreatedAtRoute("DefaultApi", new { id = parentDevice.Id }, parentDevice);
        }

        /// <summary>
        /// POST: api/ParentDevices/5/3
        /// </summary>
        /// <param name="parentDeviceId">
        /// The parent device.
        /// </param>
        /// <param name="childDeviceId">
        /// The child device.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Route("api/ParentDevices/AddChildDevice/{parentDeviceId:int}/{childDeviceId:int}")]
        public async Task<IHttpActionResult> PostChildDevice(Guid parentDeviceId, Guid childDeviceId)
        {
            var parentDevice = await this.dataContext.Devices.OfType<ParentDevice>().SingleAsync(d => d.Id == parentDeviceId);
            if (parentDevice == null)
            {
                return this.BadRequest("parentDeviceId is not valid.");
            }

            var childDevice = await this.dataContext.Devices.OfType<ChildDevice>().SingleAsync(d => d.Id == childDeviceId);
            if (childDevice == null)
            {
                return this.BadRequest("childDeviceId is not valid.");
            }

            if (parentDevice.ChildDevices.Any(d => d.Id == childDeviceId))
            {
                return this.Ok();
            }

            parentDevice.ChildDevices.Add(childDevice);
            await this.dataContext.SaveChangesAsync();

            return this.Ok();
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
        /// The parent device exists.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool ParentDeviceExists(Guid id)
        {
            return this.dataContext.Devices.Count(e => e.Id == id) > 0;
        }

        /// <summary>
        /// The parent device exists.
        /// </summary>
        /// <param name="androidId">
        /// The androidId.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool ParentDeviceExists(string androidId)
        {
            return this.dataContext.Devices.Any(e => e.AndroidId == androidId);
        }
    }
}
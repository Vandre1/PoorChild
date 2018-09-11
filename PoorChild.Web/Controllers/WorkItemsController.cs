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
    /// The work items controller.
    /// </summary>
    public class WorkItemsController : ApiController
    {
        /// <summary>
        /// The data context.
        /// </summary>
        private DataContext dataContext = new DataContext();

        /// <summary>
        /// GET: api/WorkItems
        /// </summary>
        /// <param name="childDeviceId">
        /// The child Device Id.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<WorkItem> GetWorkItems(Guid childDeviceId)
        {
            return this.dataContext.WorkItems.Where(w => w.ChildDevice.Id == childDeviceId);
        }

        /// <summary>
        /// GET: api/WorkItems/5
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [ResponseType(typeof(WorkItem))]
        public async Task<IHttpActionResult> GetWorkItem(int id)
        {
            WorkItem workItem = await this.dataContext.WorkItems.FindAsync(id);
            if (workItem == null)
            {
                return this.NotFound();
            }

            return this.Ok(workItem);
        }

        /// <summary>
        /// PUT: api/WorkItems/5
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="workItem">
        /// The work item.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWorkItem(int id, WorkItem workItem)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != workItem.Id)
            {
                return this.BadRequest();
            }

            this.dataContext.Entry(workItem).State = EntityState.Modified;

            try
            {
                await this.dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.WorkItemExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// POST: api/WorkItems
        /// </summary>
        /// <param name="workItem">
        /// The work item.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [ResponseType(typeof(WorkItem))]
        public async Task<IHttpActionResult> PostWorkItem(WorkItem workItem)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.dataContext.WorkItems.Add(workItem);
            await this.dataContext.SaveChangesAsync();

            return this.CreatedAtRoute("DefaultApi", new { id = workItem.Id }, workItem);
        }

        /// <summary>
        /// DELETE: api/WorkItems/5
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [ResponseType(typeof(WorkItem))]
        public async Task<IHttpActionResult> DeleteWorkItem(int id)
        {
            WorkItem workItem = await this.dataContext.WorkItems.FindAsync(id);
            if (workItem == null)
            {
                return this.NotFound();
            }

            this.dataContext.WorkItems.Remove(workItem);
            await this.dataContext.SaveChangesAsync();

            return this.Ok(workItem);
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
        /// The work item exists.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool WorkItemExists(int id)
        {
            return this.dataContext.WorkItems.Count(e => e.Id == id) > 0;
        }
    }
}
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
    /// The comments controller.
    /// </summary>
    public class CommentsController : ApiController
    {
        /// <summary>
        /// The data context.
        /// </summary>
        private DataContext dataContext = new DataContext();

        /// <summary>
        /// GET: api/Comments/5
        /// </summary>
        /// <param name="workItemId">
        /// The work item id.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Comment> GetComments(int workItemId)
        {
            return this.dataContext.Comments.Where(c => c.Id == workItemId);
        }

        /// <summary>
        /// PUT: api/Comments/5
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="comment">
        /// The comment.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutComment(int id, Comment comment)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != comment.Id)
            {
                return this.BadRequest();
            }

            this.dataContext.Entry(comment).State = EntityState.Modified;

            try
            {
                await this.dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.CommentExists(id))
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
        /// POST: api/Comments
        /// </summary>
        /// <param name="comment">
        /// The comment.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [ResponseType(typeof(Comment))]
        public async Task<IHttpActionResult> PostComment(Comment comment)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.dataContext.Comments.Add(comment);
            await this.dataContext.SaveChangesAsync();

            return this.CreatedAtRoute("DefaultApi", new { id = comment.Id }, comment);
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
        /// The comment exists.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CommentExists(int id)
        {
            return this.dataContext.Comments.Count(e => e.Id == id) > 0;
        }
    }
}
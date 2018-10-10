namespace PoorChild.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using PoorChild.Web.Models;

    /// <summary>
    /// The photos controller.
    /// </summary>
    public class PhotosController : ApiController
    {
        /// <summary>
        /// The dataContext.
        /// </summary>
        private DataContext dataContext = new DataContext();

        /// <summary>
        /// The get image mime type.
        /// </summary>
        /// <param name="stream">
        /// The stream.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ReadImageMimeType(Stream stream)
        {
            // see http://www.mikekunz.com/image_file_header.html
            var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
            var png = new byte[] { 137, 80, 78, 71 };    // PNG
            var tiff = new byte[] { 73, 73, 42 };         // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };         // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 }; // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 }; // jpeg canon

            var buffer = new byte[4];
            stream.Read(buffer, 0, buffer.Length);

            if (bmp.SequenceEqual(buffer.Take(bmp.Length)))
            {
                return "image/bmp";
            }

            if (gif.SequenceEqual(buffer.Take(gif.Length)))
            {
                return "image/gif";
            }

            if (png.SequenceEqual(buffer.Take(png.Length)))
            {
                return "image/png";
            }

            if (tiff.SequenceEqual(buffer.Take(tiff.Length)))
            {
                return "image/tiff";
            }

            if (tiff2.SequenceEqual(buffer.Take(tiff2.Length)))
            {
                return "image/tiff";
            }

            if (jpeg.SequenceEqual(buffer.Take(jpeg.Length)))
            {
                return "image/jpeg";
            }

            if (jpeg2.SequenceEqual(buffer.Take(jpeg2.Length)))
            {
                return "image/jpeg";
            }

            return "image/jpeg";
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        public HttpResponseMessage Get(string id)
        {
            var guid = Guid.Parse(id);
            var photo = this.dataContext.Photos.Single(p => p.Id == guid);

            using (var memoryStream = new MemoryStream(photo.PhotoData.Data, 0, photo.PhotoData.Data.Length))
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(memoryStream.ToArray());
                result.Content.Headers.ContentType = new MediaTypeHeaderValue(ReadImageMimeType(memoryStream));

                return result;
            }
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
    }
}
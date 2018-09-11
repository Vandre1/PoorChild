namespace PoorChild.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using PoorChild.Web.Models;

    /// <summary>
    /// The configuration.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<PoorChild.Web.Models.DataContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        /// <summary>
        /// The seed.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Seed(PoorChild.Web.Models.DataContext context)
        {
            ////context.Devices.AddOrUpdate(
            ////    x => x.Id,
            ////    new ParentDevice() { DateTimeDeviceRegisteredInUtc = DateTime.UtcNow, AndroidId = "test1@avorobyev.com" },
            ////    new ParentDevice() { DateTimeDeviceRegisteredInUtc = DateTime.UtcNow, AndroidId = "test2@avorobyev.com" },
            ////    new ParentDevice() { DateTimeDeviceRegisteredInUtc = DateTime.UtcNow, AndroidId = "test3@avorobyev.com" }
            ////);
        }
    }
}

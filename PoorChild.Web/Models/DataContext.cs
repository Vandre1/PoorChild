namespace PoorChild.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// The data context.
    /// </summary>
    public class DataContext : DbContext
    {
        // Your context has been configured to use a 'DataContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PoorChild.Web.Models.DataContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DataContext' 
        // connection string in the application configuration file.

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// </summary>
        public DataContext() : base("name=DataContext")
        {
            // recreate database
            // update-database -TargetMigration:0 | update-database -force
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        /// <summary>
        /// Gets or sets the devices.
        /// </summary>
        public virtual DbSet<Device> Devices { get; set; }

        /// <summary>
        /// Gets or sets the work items.
        /// </summary>
        public virtual DbSet<WorkItem> WorkItems { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        public virtual DbSet<Comment> Comments { get; set; }

        /// <summary>
        /// Gets or sets the photo datas.
        /// </summary>
        public virtual DbSet<PhotoData> PhotoDatas { get; set; }

        /// <summary>
        /// Gets or sets the photos.
        /// </summary>
        public virtual DbSet<Photo> Photos { get; set; }
    }
}
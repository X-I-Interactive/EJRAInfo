using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTMLFileContent.Repository.Conventions;
using HTMLFileContent.Repository.HTMLFileContentClasses;

namespace HTMLFileContent.RepositoryDatabase
{
    public class HTMLFileContentDbContext : DbContext
    {
        public HTMLFileContentDbContext() : base("CHFConnectionString")
        {

        }

        public HTMLFileContentDbContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<HTMLContent> HTMLContent { get; set; }
        public DbSet<ContentItem> ContentItems { get; set; }
        public DbSet<W3SVCLogFile> W3SVCLogFile { get; set; }
        public DbSet<W3SVCLogFilesProcessed> W3SVCLogFilesProcessed { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new DateTime2Convention());
        }

    }

    /* short guide
         * 
         * Tools -> NuGet Package Manager -> Package Manager Console
         * Select CarolineCottage.Repository from project list
         * Ensure that the project will build successfully.
         * enable-migrations -ContextTypeName: HTMLFileContentDbContext -MigrationsDirectory:Migrations
         * Add-Migration HTMLFileContentMigrations
         * Update-database
         * 
         *      Update-Database -Script -SourceMigration:"BaseName" -TargetMigration:"TargetName"
         *      Update-database TargetMigration:0
         *      Update-Database -TargetMigration $InitialDatabase'
         *      Update-Database -Script -SourceMigration:"201512070002273_CarolineCottageMigrations" -TargetMigration:"201512070002273_CarolineCottageMigrations"
         *      Update-Database -Script -SourceMigration:"201411191320595_ChristmasTwoMigrations3" -TargetMigration:"201411281838563_ChristmasTwoMigrations4"
         */
}

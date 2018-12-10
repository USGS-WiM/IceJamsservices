//------------------------------------------------------------------------------
//----- DB Context ---------------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2017 WiM - USGS

//    authors:  Jeremy K. Newson USGS Web Informatics and Mapping
//              
//  
//   purpose:   Responsible for interacting with Database 
//
//discussion:   The primary class that is responsible for interacting with data as objects. 
//              The context class manages the entity objects during run time, which includes 
//              populating objects with data from a database, change tracking, and persisting 
//              data to the database.
//              
//
//   

using Microsoft.EntityFrameworkCore;
using IceJamsDB.Resources;
using System;
using System.IO;
using Newtonsoft.Json;
//specifying the data provider and connection string
namespace IceJamsDB
{
    public class IceJamsDBContext:DbContext
    {
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Damage> Damages { get; set; }
        public DbSet<DamageType> DamageTypes { get; set; }
        public DbSet<Resources.File> Files { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<IceCondition> IceConditions { get; set; }
        public DbSet<IceConditionType> IceConditionTypes { get; set; }
        public DbSet<IceJam> IceJams { get; set; }
        public DbSet<JamType> JamTypes { get; set; }
        public DbSet<Observer> Observers { get; set; }
        public DbSet<RiverCondition> RiverConditions { get; set; }
        public DbSet<RiverConditionType> RiverConditionTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoughnessType> RoughnessTypes { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<StageType> StageTypes { get; set; }
        public DbSet<WeatherCondition> WeatherConditions { get; set; }
        public DbSet<WeatherConditionType> WeatherConditionTypes { get; set; }

        public IceJamsDBContext() : base()
        {
        }
        public IceJamsDBContext(DbContextOptions<IceJamsDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("postgis");
            //schema
            modelBuilder.HasDefaultSchema("icejam");

            //Specify unique constraints
            //EF Core currently does not support changing the value of alternate keys. We do have #4073 tracking removing this restriction though.
            //BTW it only needs to be an alternate key if you want it to be used as the target key of a relationship.If you just want a unique index, 
            //then use the HasIndex() method, rather than AlternateKey().Unique index values can be changed.
            modelBuilder.Entity<DamageType>().HasIndex(k => k.Name).IsUnique();
            modelBuilder.Entity<FileType>().HasIndex(k => k.Name).IsUnique();
            modelBuilder.Entity<IceConditionType>().HasIndex(k => k.Name).IsUnique();
            modelBuilder.Entity<JamType>().HasIndex(k => k.Name).IsUnique();
            modelBuilder.Entity<Observer>().HasIndex(k => k.Username).IsUnique();
            modelBuilder.Entity<RiverConditionType>().HasIndex(k => k.Name).IsUnique();
            modelBuilder.Entity<RoughnessType>().HasIndex(k => k.Name).IsUnique();
            modelBuilder.Entity<StageType>().HasIndex(k => k.Name).IsUnique();
            
            //add shadowstate  
            //https://stackoverflow.com/questions/9556474/how-do-i-automatically-update-a-timestamp-in-postgresql
            //https://x-team.com/blog/automatic-timestamps-with-postgresql/
            foreach (var entitytype in modelBuilder.Model.GetEntityTypes())
            {
                if (entitytype.Name.EndsWith("Type")) continue;
                modelBuilder.Entity(entitytype.Name).Property<DateTime>("LastModified");
            }//next entitytype

            //cascade delete is default, rewrite behavior
            modelBuilder.Entity(typeof(Observer).ToString(), b =>
            {
                b.HasOne(typeof(Role), "Role")
                    .WithMany()
                    .HasForeignKey("RoleID")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(Agency), "Agency")
                    .WithMany()
                    .HasForeignKey("AgencyID")
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity(typeof(IceJam), b => {
                b.HasOne(typeof(JamType), "Type")
                .WithMany()
                .HasForeignKey("JamTypeID")
                .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(Observer), "Observer")
                  .WithMany()
                  .HasForeignKey("ObserverID")
                  .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(Site), "Site")
                  .WithMany()
                  .HasForeignKey("SiteID")
                  .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity(typeof(Resources.File), b => {
                b.HasOne(typeof(FileType), "Type")
                .WithMany()
                .HasForeignKey("FileTypeID")
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity(typeof(Damage), b => {
                b.HasOne(typeof(DamageType), "Type")
                .WithMany()
                .HasForeignKey("DamageTypeID")
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity(typeof(WeatherCondition), b => {
                b.HasOne(typeof(WeatherConditionType), "Type")
                .WithMany()
                .HasForeignKey("WeatherConditionTypeID")
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity(typeof(RiverCondition), b => {
                b.HasOne(typeof(RiverConditionType), "Type")
                .WithMany()
                .HasForeignKey("RiverConditionTypeID")
                .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(StageType), "StageType")
                .WithMany()
                .HasForeignKey("StageTypeID")
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity(typeof(IceCondition), b => {
                b.HasOne(typeof(IceConditionType), "Type")
                .WithMany()
                .HasForeignKey("IceConditionTypeID")
                .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(typeof(RoughnessType), "RoughnessType")
                .WithMany()
                .HasForeignKey("RoughnessTypeID")
                .OnDelete(DeleteBehavior.Restrict);
            });

            //seed the db - Must be commented out after migration
            //var path = Path.Combine(Environment.CurrentDirectory, "Data");
            //modelBuilder.Entity<Agency>().HasData(JsonConvert.DeserializeObject<Agency[]>(System.IO.File.ReadAllText(Path.Combine(path, "Agency.json"))));
            //modelBuilder.Entity<DamageType>().HasData(JsonConvert.DeserializeObject<DamageType[]>(System.IO.File.ReadAllText(Path.Combine(path, "DamageType.json"))));
            //modelBuilder.Entity<FileType>().HasData(JsonConvert.DeserializeObject<FileType[]>(System.IO.File.ReadAllText(Path.Combine(path, "FileType.json"))));
            //modelBuilder.Entity<IceConditionType>().HasData(JsonConvert.DeserializeObject<IceConditionType[]>(System.IO.File.ReadAllText(Path.Combine(path, "IceConditionType.json"))));
            //modelBuilder.Entity<JamType>().HasData(JsonConvert.DeserializeObject<JamType[]>(System.IO.File.ReadAllText(Path.Combine(path, "JamType.json"))));
            //modelBuilder.Entity<RiverConditionType>().HasData(JsonConvert.DeserializeObject<RiverConditionType[]>(System.IO.File.ReadAllText(Path.Combine(path, "RiverConditionType.json"))));
            //modelBuilder.Entity<Role>().HasData(JsonConvert.DeserializeObject<Role[]>(System.IO.File.ReadAllText(Path.Combine(path, "Role.json"))));
            //modelBuilder.Entity<RoughnessType>().HasData(JsonConvert.DeserializeObject<RoughnessType[]>(System.IO.File.ReadAllText(Path.Combine(path, "RoughnessType.json"))));
            //modelBuilder.Entity<StageType>().HasData(JsonConvert.DeserializeObject<StageType[]>(System.IO.File.ReadAllText(Path.Combine(path, "StageType.json"))));
            //modelBuilder.Entity<WeatherConditionType>().HasData(JsonConvert.DeserializeObject<WeatherConditionType[]>(System.IO.File.ReadAllText(Path.Combine(path, "WeatherConditionType.json"))));

            //modelBuilder.Entity<Site>().HasData(JsonConvert.DeserializeObject<Site[]>(System.IO.File.ReadAllText(Path.Combine(path, "Site.json"))));
            //modelBuilder.Entity<IceJam>().HasData(JsonConvert.DeserializeObject<IceJam[]>(System.IO.File.ReadAllText(Path.Combine(path, "Event.json"))));

            base.OnModelCreating(modelBuilder);             
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning Add connectionstring for migrations
            var connectionstring = "User ID=;Password=;Host=pgtest.ck2zppz9pgsw.us-east-1.rds.amazonaws.com;Port=5432;Database=icejam;Pooling=true;";
            //optionsBuilder.UseNpgsql(connectionstring,x=> { x.MigrationsHistoryTable("_EFMigrationsHistory", "icejam"); x.UseNetTopologySuite(); });

        }
    }
}

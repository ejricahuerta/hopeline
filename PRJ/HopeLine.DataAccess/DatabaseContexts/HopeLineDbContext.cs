﻿
using HopeLine.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace HopeLine.DataAccess.DatabaseContexts
{

    //TODO : Add References to Identity

    /// <summary>
    /// 
    /// </summary>
    public class HopeLineDbContext : IdentityDbContext<HopeLineUser>
    {
        public HopeLineDbContext()
        {

        }
        #region all accounts
        public DbSet<AdminAccount> AdminAccounts { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<MentorAccount> MentorAccounts { get; set; }
        public DbSet<GuestAccount> GuestAccounts { get; set; }
        #endregion
        // TODO : Add all entities

        //public Dbset<> MyProperty { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Topic> Topics { get; set; }


        /// <summary>
        /// Override constructor with options
        /// </summary>
        /// <param name="options"></param>
        public HopeLineDbContext(DbContextOptions<HopeLineDbContext> options) : base(options)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO : move to appsettings.json file
            optionsBuilder.UseSqlServer("Server=tcp:prj.database.windows.net,1433;Initial Catalog=HopeLineDB;Persist Security Info=False;User ID=hopeline;Password=Prjgroup7;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //this is a temporary fix EF team is removing all many to many relationship soon
            //https://github.com/aspnet/EntityFrameworkCore/issues/1368


            #region profile and language many to many relationship
            modelBuilder.Entity<ProfileLanguage>()
                .HasKey(k => new { k.ProfileId, k.LanguageId });

            modelBuilder.Entity<ProfileLanguage>()
                .HasOne(p => p.Profile)
                .WithMany(l => l.ProfileLanguages)
                .HasForeignKey(pl => pl.ProfileId);

            modelBuilder.Entity<ProfileLanguage>()
                .HasOne(p => p.Language)
                .WithMany(l => l.ProfileLanguages)
                .HasForeignKey(pl => pl.LanguageId);
            #endregion

        }

    }
}

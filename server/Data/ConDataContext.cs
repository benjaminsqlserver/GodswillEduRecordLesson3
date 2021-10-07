using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using GodswillEduRecord.Models.ConData;

namespace GodswillEduRecord.Data
{
  public partial class ConDataContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public ConDataContext(DbContextOptions<ConDataContext> options):base(options)
    {
    }

    public ConDataContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<GodswillEduRecord.Models.ConData.NextOfKin>()
              .HasOne(i => i.StudentBiodatum)
              .WithMany(i => i.NextOfKins)
              .HasForeignKey(i => i.BiodataID)
              .HasPrincipalKey(i => i.BiodataID);
        builder.Entity<GodswillEduRecord.Models.ConData.NextOfKin>()
              .HasOne(i => i.Relationship)
              .WithMany(i => i.NextOfKins)
              .HasForeignKey(i => i.RelationshipID)
              .HasPrincipalKey(i => i.RelationshipID);
        builder.Entity<GodswillEduRecord.Models.ConData.StudentBiodatum>()
              .HasOne(i => i.Gender)
              .WithMany(i => i.StudentBiodata)
              .HasForeignKey(i => i.GenderID)
              .HasPrincipalKey(i => i.GenderID);
        builder.Entity<GodswillEduRecord.Models.ConData.StudentBiodatum>()
              .HasOne(i => i.State)
              .WithMany(i => i.StudentBiodata)
              .HasForeignKey(i => i.StateOfOriginID)
              .HasPrincipalKey(i => i.StateID);
        builder.Entity<GodswillEduRecord.Models.ConData.StudentCoursePayment>()
              .HasOne(i => i.StudentBiodatum)
              .WithMany(i => i.StudentCoursePayments)
              .HasForeignKey(i => i.BiodataID)
              .HasPrincipalKey(i => i.BiodataID);
        builder.Entity<GodswillEduRecord.Models.ConData.StudentCoursePayment>()
              .HasOne(i => i.SchoolCourse)
              .WithMany(i => i.StudentCoursePayments)
              .HasForeignKey(i => i.CourseOfStudyID)
              .HasPrincipalKey(i => i.CourseOfStudyID);
        builder.Entity<GodswillEduRecord.Models.ConData.StudentCourseRegistration>()
              .HasOne(i => i.StudentBiodatum)
              .WithMany(i => i.StudentCourseRegistrations)
              .HasForeignKey(i => i.BiodataID)
              .HasPrincipalKey(i => i.BiodataID);
        builder.Entity<GodswillEduRecord.Models.ConData.StudentCourseRegistration>()
              .HasOne(i => i.SchoolCourse)
              .WithMany(i => i.StudentCourseRegistrations)
              .HasForeignKey(i => i.CourseOfStudyID)
              .HasPrincipalKey(i => i.CourseOfStudyID);
        builder.Entity<GodswillEduRecord.Models.ConData.StudentCourseRegistration>()
              .HasOne(i => i.StudySession)
              .WithMany(i => i.StudentCourseRegistrations)
              .HasForeignKey(i => i.StudySessionID)
              .HasPrincipalKey(i => i.StudySessionID);
        builder.Entity<GodswillEduRecord.Models.ConData.StudentEducationHistory>()
              .HasOne(i => i.StudentBiodatum)
              .WithMany(i => i.StudentEducationHistories)
              .HasForeignKey(i => i.BiodataID)
              .HasPrincipalKey(i => i.BiodataID);
        builder.Entity<GodswillEduRecord.Models.ConData.StudentEducationHistory>()
              .HasOne(i => i.Qualification)
              .WithMany(i => i.StudentEducationHistories)
              .HasForeignKey(i => i.QualificationObtainedID)
              .HasPrincipalKey(i => i.QualificationID);


        builder.Entity<GodswillEduRecord.Models.ConData.StudentBiodatum>()
              .Property(p => p.DateOfBirth)
              .HasColumnType("datetime2");

        builder.Entity<GodswillEduRecord.Models.ConData.StudentCoursePayment>()
              .Property(p => p.PaymentDate)
              .HasColumnType("datetime");

        builder.Entity<GodswillEduRecord.Models.ConData.StudentEducationHistory>()
              .Property(p => p.StartDate)
              .HasColumnType("datetime2");

        builder.Entity<GodswillEduRecord.Models.ConData.StudentEducationHistory>()
              .Property(p => p.EndDate)
              .HasColumnType("datetime2");

        builder.Entity<GodswillEduRecord.Models.ConData.Gender>()
              .Property(p => p.GenderID)
              .HasPrecision(10, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.NextOfKin>()
              .Property(p => p.NextOfKinID)
              .HasPrecision(19, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.NextOfKin>()
              .Property(p => p.BiodataID)
              .HasPrecision(19, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.NextOfKin>()
              .Property(p => p.RelationshipID)
              .HasPrecision(10, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.Qualification>()
              .Property(p => p.QualificationID)
              .HasPrecision(10, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.Relationship>()
              .Property(p => p.RelationshipID)
              .HasPrecision(10, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.SchoolCourse>()
              .Property(p => p.CourseOfStudyID)
              .HasPrecision(10, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.SchoolCourse>()
              .Property(p => p.CourseFee)
              .HasPrecision(18, 2);

        builder.Entity<GodswillEduRecord.Models.ConData.SchoolCourse>()
              .Property(p => p.DurationInMonths)
              .HasPrecision(10, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.State>()
              .Property(p => p.StateID)
              .HasPrecision(10, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.StudentBiodatum>()
              .Property(p => p.BiodataID)
              .HasPrecision(19, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.StudentBiodatum>()
              .Property(p => p.GenderID)
              .HasPrecision(10, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.StudentBiodatum>()
              .Property(p => p.StateOfOriginID)
              .HasPrecision(10, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.StudentCoursePayment>()
              .Property(p => p.PaymentID)
              .HasPrecision(19, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.StudentCoursePayment>()
              .Property(p => p.BiodataID)
              .HasPrecision(19, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.StudentCoursePayment>()
              .Property(p => p.CourseOfStudyID)
              .HasPrecision(10, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.StudentCoursePayment>()
              .Property(p => p.CourseFee)
              .HasPrecision(18, 2);

        builder.Entity<GodswillEduRecord.Models.ConData.StudentCoursePayment>()
              .Property(p => p.AmountPaid)
              .HasPrecision(18, 2);

        builder.Entity<GodswillEduRecord.Models.ConData.StudentCoursePayment>()
              .Property(p => p.Balance)
              .HasPrecision(18, 2);

        builder.Entity<GodswillEduRecord.Models.ConData.StudentCourseRegistration>()
              .Property(p => p.CourseRegistrationID)
              .HasPrecision(19, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.StudentCourseRegistration>()
              .Property(p => p.BiodataID)
              .HasPrecision(19, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.StudentCourseRegistration>()
              .Property(p => p.CourseOfStudyID)
              .HasPrecision(10, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.StudentCourseRegistration>()
              .Property(p => p.StudySessionID)
              .HasPrecision(10, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.StudentEducationHistory>()
              .Property(p => p.EducationRecordID)
              .HasPrecision(19, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.StudentEducationHistory>()
              .Property(p => p.BiodataID)
              .HasPrecision(19, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.StudentEducationHistory>()
              .Property(p => p.QualificationObtainedID)
              .HasPrecision(10, 0);

        builder.Entity<GodswillEduRecord.Models.ConData.StudySession>()
              .Property(p => p.StudySessionID)
              .HasPrecision(10, 0);
        this.OnModelBuilding(builder);
    }


    public DbSet<GodswillEduRecord.Models.ConData.Gender> Genders
    {
      get;
      set;
    }

    public DbSet<GodswillEduRecord.Models.ConData.NextOfKin> NextOfKins
    {
      get;
      set;
    }

    public DbSet<GodswillEduRecord.Models.ConData.Qualification> Qualifications
    {
      get;
      set;
    }

    public DbSet<GodswillEduRecord.Models.ConData.Relationship> Relationships
    {
      get;
      set;
    }

    public DbSet<GodswillEduRecord.Models.ConData.SchoolCourse> SchoolCourses
    {
      get;
      set;
    }

    public DbSet<GodswillEduRecord.Models.ConData.State> States
    {
      get;
      set;
    }

    public DbSet<GodswillEduRecord.Models.ConData.StudentBiodatum> StudentBiodata
    {
      get;
      set;
    }

    public DbSet<GodswillEduRecord.Models.ConData.StudentCoursePayment> StudentCoursePayments
    {
      get;
      set;
    }

    public DbSet<GodswillEduRecord.Models.ConData.StudentCourseRegistration> StudentCourseRegistrations
    {
      get;
      set;
    }

    public DbSet<GodswillEduRecord.Models.ConData.StudentEducationHistory> StudentEducationHistories
    {
      get;
      set;
    }

    public DbSet<GodswillEduRecord.Models.ConData.StudySession> StudySessions
    {
      get;
      set;
    }
  }
}

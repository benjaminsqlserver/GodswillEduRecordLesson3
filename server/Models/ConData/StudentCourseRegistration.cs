using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodswillEduRecord.Models.ConData
{
  [Table("StudentCourseRegistrations", Schema = "dbo")]
  public partial class StudentCourseRegistration
  {
    [NotMapped]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("@odata.etag")]
    public string ETag
    {
        get;
        set;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int64 CourseRegistrationID
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public Int64 BiodataID
    {
      get;
      set;
    }
    public StudentBiodatum StudentBiodatum { get; set; }
    [ConcurrencyCheck]
    public int CourseOfStudyID
    {
      get;
      set;
    }
    public SchoolCourse SchoolCourse { get; set; }
    [ConcurrencyCheck]
    public int StudySessionID
    {
      get;
      set;
    }
    public StudySession StudySession { get; set; }
    [ConcurrencyCheck]
    public bool? IsPrivateStudent
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string PrivateTrainingVenue
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string PrivateTrainingTime
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Signature
    {
      get;
      set;
    }
  }
}

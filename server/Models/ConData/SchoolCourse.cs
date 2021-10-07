using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodswillEduRecord.Models.ConData
{
  [Table("SchoolCourses", Schema = "dbo")]
  public partial class SchoolCourse
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
    public int CourseOfStudyID
    {
      get;
      set;
    }

    public IEnumerable<StudentCourseRegistration> StudentCourseRegistrations { get; set; }
    public IEnumerable<StudentCoursePayment> StudentCoursePayments { get; set; }
    [ConcurrencyCheck]
    public string CourseOfStudyName
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public decimal? CourseFee
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int DurationInMonths
    {
      get;
      set;
    }
  }
}

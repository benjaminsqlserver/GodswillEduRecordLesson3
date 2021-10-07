using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodswillEduRecord.Models.ConData
{
  [Table("StudentCoursePayments", Schema = "dbo")]
  public partial class StudentCoursePayment
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
    public Int64 PaymentID
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
    public DateTime PaymentDate
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public decimal CourseFee
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public decimal AmountPaid
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public decimal Balance
    {
      get;
      set;
    }
  }
}

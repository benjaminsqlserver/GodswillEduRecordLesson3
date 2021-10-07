using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodswillEduRecord.Models.ConData
{
  [Table("StudentBiodata", Schema = "dbo")]
  public partial class StudentBiodatum
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
    public Int64 BiodataID
    {
      get;
      set;
    }

    public IEnumerable<StudentEducationHistory> StudentEducationHistories { get; set; }
    public IEnumerable<NextOfKin> NextOfKins { get; set; }
    public IEnumerable<StudentCourseRegistration> StudentCourseRegistrations { get; set; }
    public IEnumerable<StudentCoursePayment> StudentCoursePayments { get; set; }
    [ConcurrencyCheck]
    public string Surname
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string FirstName
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string OtherNames
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string ContactAddress
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime DateOfBirth
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int GenderID
    {
      get;
      set;
    }
    public Gender Gender { get; set; }
    [ConcurrencyCheck]
    public int StateOfOriginID
    {
      get;
      set;
    }
    public State State { get; set; }
    [ConcurrencyCheck]
    public string PhoneNumber
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string EmailAddress
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string FacebookID
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Picture
    {
      get;
      set;
    }
  }
}

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodswillEduRecord.Models.ConData
{
  [Table("StudySessions", Schema = "dbo")]
  public partial class StudySession
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
    public int StudySessionID
    {
      get;
      set;
    }

    public IEnumerable<StudentCourseRegistration> StudentCourseRegistrations { get; set; }
    [ConcurrencyCheck]
    public string StudySessionName
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Time
    {
      get;
      set;
    }
  }
}

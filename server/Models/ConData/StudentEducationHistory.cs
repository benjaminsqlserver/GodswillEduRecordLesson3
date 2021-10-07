using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodswillEduRecord.Models.ConData
{
  [Table("StudentEducationHistories", Schema = "dbo")]
  public partial class StudentEducationHistory
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
    public Int64 EducationRecordID
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
    public string NameOfInstitution
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime StartDate
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime? EndDate
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int QualificationObtainedID
    {
      get;
      set;
    }
    public Qualification Qualification { get; set; }
  }
}

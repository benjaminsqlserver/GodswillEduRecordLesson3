using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodswillEduRecord.Models.ConData
{
  [Table("Qualifications", Schema = "dbo")]
  public partial class Qualification
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
    public int QualificationID
    {
      get;
      set;
    }

    public IEnumerable<StudentEducationHistory> StudentEducationHistories { get; set; }
    [ConcurrencyCheck]
    public string QualificationName
    {
      get;
      set;
    }
  }
}

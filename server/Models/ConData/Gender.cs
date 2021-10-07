using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodswillEduRecord.Models.ConData
{
  [Table("Genders", Schema = "dbo")]
  public partial class Gender
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
    public int GenderID
    {
      get;
      set;
    }

    public IEnumerable<StudentBiodatum> StudentBiodata { get; set; }
    [ConcurrencyCheck]
    public string GenderName
    {
      get;
      set;
    }
  }
}

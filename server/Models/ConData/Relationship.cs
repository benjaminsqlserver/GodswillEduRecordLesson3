using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodswillEduRecord.Models.ConData
{
  [Table("Relationships", Schema = "dbo")]
  public partial class Relationship
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
    public int RelationshipID
    {
      get;
      set;
    }

    public IEnumerable<NextOfKin> NextOfKins { get; set; }
    [ConcurrencyCheck]
    public string RelationshipName
    {
      get;
      set;
    }
  }
}

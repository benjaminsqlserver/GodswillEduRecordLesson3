using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodswillEduRecord.Models.ConData
{
  [Table("NextOfKins", Schema = "dbo")]
  public partial class NextOfKin
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
    public Int64 NextOfKinID
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
    public string NameOfNextOfKin
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int RelationshipID
    {
      get;
      set;
    }
    public Relationship Relationship { get; set; }
    [ConcurrencyCheck]
    public string NextOfKinPhoneNo
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string NextOfKinEmail
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string NextOfKinContactAddress
    {
      get;
      set;
    }
  }
}

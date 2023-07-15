using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataAccess.Models;

[Table("space_x_event")]
public class SpaceXEventModel
{
    [JsonIgnore]
    [Key, Column("id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column("title")]
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [Column("event_date_utc")]
    [JsonPropertyName("event_date_utc")]
    public DateTime EventDateUtc { get; set; }

    [Column("event_date_unix")]
    [JsonPropertyName("event_date_unix")]
    public long EventDateUnix { get; set; }

    [Column("details")]
    [JsonPropertyName("details")]
    public string Details { get; set; }

    [Column("links")]
    [JsonPropertyName("links")]
    public LinksModel Links { get; set; }
    //[JsonIgnore]
    //[Column("links_id")]
    //public long LinksId { get; set; }
}
[Table("links")]
public class LinksModel
{
    //[JsonIgnore]
    [Key, Column("id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column("article")]
    [JsonPropertyName("article")]
    public string Article { get; set; }
}

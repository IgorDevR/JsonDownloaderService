namespace DataAccess.Dto;

public class SpaceXEventDto
{
    public string Title { get; set; }
    
    public DateTime EventDateUtc { get; set; }

    public long EventDateUnix { get; set; }

    public string Details { get; set; }

    public LinksModel Links { get; set; }

}
public class LinksModel
{
    public string Article { get; set; }
}
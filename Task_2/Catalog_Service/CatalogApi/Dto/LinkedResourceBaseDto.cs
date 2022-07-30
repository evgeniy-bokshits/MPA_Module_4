namespace CatalogApi.Dto;

public abstract class LinkedResourceBaseDto
{
    public List<LinkDto> Links { get; set; } = new List<LinkDto>();
}

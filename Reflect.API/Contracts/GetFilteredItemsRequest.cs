namespace Reflect.API.Contracts;

public class GetFilteredItemsRequest
{
    public string TypeContent { get; set; }
    public int? StartFilterYear { get; set; }
    public int? StopFilterYear { get; set; }
    public string[]? FilterTags { get; set; }
}
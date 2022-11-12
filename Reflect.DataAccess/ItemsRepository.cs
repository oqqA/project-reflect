namespace Reflect.DataAccess;
public class ItemsRepository
{
    public static Item[] GetFilter(string typeContent, string[]? filterTags = null, int? StartFilterYear = null, int? StopFilterYear = null)
    {
        var result = new List<Item>();

        //...

        return result.ToArray();
    }
}

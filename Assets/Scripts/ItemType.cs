using System.Collections.Generic;

public enum ItemType
{
    Grain,
}

public class Items
{
    public static Dictionary<ItemType, string> names = new Dictionary<ItemType, string>()
    {
        { ItemType.Grain, "grain" }
    };
}
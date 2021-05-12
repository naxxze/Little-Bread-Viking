using System.Collections.Generic;

public enum ItemType
{
    Grain,
    Salt,
    Sugar
}

public class Items
{
    public static Dictionary<ItemType, string> names = new Dictionary<ItemType, string>()
    {
        { ItemType.Grain, "grain" },
        { ItemType.Salt, "salt" },
        { ItemType.Sugar, "sugar" },
    };
}
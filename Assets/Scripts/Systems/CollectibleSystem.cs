using System;
using System.Collections.Generic;

public class CollectibleSystem
{
    private Dictionary<ItemType, int> inventory;

    public CollectibleSystem()
    {
        this.inventory = new Dictionary<ItemType, int>();
    }

    public void Collect(ItemType item)
    {
        this.inventory.TryGetValue(item, out var current);
        this.inventory[item] = current + 1;
    }

    public void Use(ItemType item, int count = 1)
    {
        this.inventory.TryGetValue(item, out var current);
        if (count > current)
        {
            string err = String.Format("Cannot use {0} items since you only have {2}.",
                count, current);
            throw new ArgumentException(err);
        }
        this.inventory[item] = current - count;
    }
}
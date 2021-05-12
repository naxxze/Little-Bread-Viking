using System;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null)
        {
            Debug.Log(String.Format("Collect item {0}",
                Items.names[item.itemType]));
            Game.Instance.GetCollectibleSystem().Collect(item.itemType);
            other.GetComponent<Destroyable>()?.Destroy();
        }
    }
}
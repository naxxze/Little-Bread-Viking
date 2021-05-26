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

            SetInvisible(other.gameObject);
            DestroyAndPlaySfx(other.gameObject);
        }
    }

    private void SetInvisible(GameObject obj)
    {
        SpriteRenderer sprite = obj.GetComponent<SpriteRenderer>();
        if (sprite)
        {
            sprite.color = Color.clear;
        }
    }

    private void DestroyAndPlaySfx(GameObject obj)
    {
        AudioSource source = obj.GetComponent<AudioSource>();
        Sfx sfx = obj.GetComponent<Sfx>();
        if (source != null && sfx != null)
        {
            sfx.PlaySfx(source);
            obj.GetComponent<Destroyable>()?.Destroy(source.clip.length);
        }
        else
        {
            obj.GetComponent<Destroyable>()?.Destroy();
        }
    }
}
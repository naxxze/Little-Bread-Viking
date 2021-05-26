using UnityEngine;

public class TintChildren : MonoBehaviour
{

    [Tooltip("Color to tint all children with")]
    public Color tint = Color.white;

    private void Update()
    {
        Tint();
    }

    private void Tint()
    {
        foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>())
        {
            sprite.color = tint;
        }
    }
}

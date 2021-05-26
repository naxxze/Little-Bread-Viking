using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    // Width a single background sprite
    private float width;
    // Origin x of the parallax effect
    private float originX;

    [Tooltip("The parallax effect is applied relative to this camera")]
    public GameObject cam;
    [Range(0, 1), Tooltip("The amount of parallax effect to apply")]
    public float effect;

    private void Start()
    {
        originX = transform.position.x;
        // Get width from first sprite
        width = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = cam.transform.position.x * (1 - effect);
        float dist = cam.transform.position.x * effect;

        transform.position = new Vector3(originX + dist, transform.position.y, transform.position.z);

        if (temp > originX + width)
            originX += width;
        else if (temp < originX - width)
            originX -= width;
    }
}

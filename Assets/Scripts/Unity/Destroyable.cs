using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField]
    private GameObject root;

    public void Destroy(float time = 0)
    {
        Destroy(root, time);
    }
}
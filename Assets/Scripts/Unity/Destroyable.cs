using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField]
    private GameObject root;

    public void Destroy()
    {
        Destroy(root);
    }
}
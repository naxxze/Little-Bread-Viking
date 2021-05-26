using UnityEngine;
using UnityEngine.Events;

public class DeathController : MonoBehaviour
{
    public UnityEvent death;

    private void Update()
    {
        if (transform.position.y < -5)
        {
            death.Invoke();
        }
    }
}

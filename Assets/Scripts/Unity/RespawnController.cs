using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private Vector3 respawnPosition;

    private void Start()
    {
        SetRespawnPoint(transform.position);
    }

    public void SetRespawnPoint(Vector3 point)
    {
        this.respawnPosition = new Vector3(point.x, point.y, point.z);
    }

    public void Respawn()
    {
        transform.position = this.respawnPosition;
    }
}

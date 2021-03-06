using UnityEngine;

public class CameraController : MonoBehaviour
{
	private GameObject player;
	
    // Start is called before the first frame update
    void Start()
    {
        player = Game.Instance.GetPlayer();
    }

    // Update is called once per frame
    void Update()
	{
		if(player.transform.position.x > transform.position.x) {
			transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
		}
    }
}

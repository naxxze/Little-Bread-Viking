using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
	public List <GameObject> Levels;
	public List <GameObject> spawned;
	private GameObject player;
	
    // Start is called before the first frame update
    void Start()
    {
        player = Game.Instance.GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {	
		int rnd;
		float foo;
		float lastpos = spawned[spawned.Count - 1].transform.position.x;
		float firstpos = spawned[0].transform.position.x;
		GameObject lvl;
        if(player.transform.position.x - lastpos > 6) {
			foo = Random.value * Levels.Count * 0.9999f;
			rnd = (int)foo;
			lvl = Instantiate(Levels[rnd], new Vector3(lastpos + 16.0f,0.0f,0.0f), Quaternion.identity);
			spawned.Add(lvl);
		}
		if(player.transform.position.x - firstpos > 22) {
			Destroy(spawned[0]);
			spawned.RemoveAt(0);
		}
    }
}

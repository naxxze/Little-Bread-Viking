using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float jumpstr;
	private Rigidbody2D rb;
	
	void Awake()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal"); 
		float vert = Input.GetAxis("Vertical"); 
		
		rb.AddForce(transform.up*jumpstr*vert);
		rb.AddForce(transform.right*speed*hori);
    }
}

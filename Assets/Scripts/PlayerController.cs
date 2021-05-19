using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float jumpstr;
	private float timeout;
	private Rigidbody2D rb;
	private HashSet<Collider2D> CurrColl = new HashSet<Collider2D>();
	
	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "Ground") CurrColl.Add(col.collider);
	}
	
	void OnCollisionExit2D(Collision2D col) {
		if(col.gameObject.tag == "Ground") CurrColl.Remove(col.collider);
	}
	
	void Awake()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        timeout = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal"); 
		float vert = Input.GetAxis("Vertical"); 
		
		timeout += Time.deltaTime;
		
		if(CurrColl.Count > 0 && vert > 0 && timeout > 0){
			rb.AddForce(transform.up*jumpstr, ForceMode2D.Impulse);
			timeout = -0.4f;
		} else if (CurrColl.Count > 0 && vert > 0 && timeout > -0.2){
			rb.AddForce(transform.up*jumpstr*0.5f, ForceMode2D.Impulse);
			timeout = -0.4f;
		}
		if(Mathf.Abs(hori) > 0.01) rb.AddForce(transform.right*(speed - Mathf.Abs(rb.velocity.x))*hori);
		else if(CurrColl.Count > 0) rb.AddForce(-transform.right*speed*Mathf.Sign(rb.velocity.x)*hori*0.2f);

    }
}


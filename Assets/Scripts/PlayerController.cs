using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float jumpstr;
	private float timeout;
	private float delay = 0.3f;
	private float fmul = 3f;
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
	
    void Start()
    {
        timeout = 0.0f;
    }
	
    void FixedUpdate()
    {	
		
        float hori = Input.GetAxis("Horizontal"); 
		float vert = Input.GetAxis("Vertical"); 
		
		timeout += Time.deltaTime;
		
		if(CurrColl.Count > 0 && vert > 0 && timeout > 0){
			rb.AddForce(transform.up*rb.mass*jumpstr, ForceMode2D.Impulse);
			timeout = -2*delay;
		} else if (CurrColl.Count > 0 && vert > 0 && timeout > -delay){
			rb.AddForce(transform.up*rb.mass*jumpstr*0.5f, ForceMode2D.Impulse);
			timeout = -2*delay;
		}
		float targetdiff = hori*speed - rb.velocity.x;
		if(Mathf.Abs(hori) > 0.01) rb.AddForce(transform.right*rb.mass*fmul*targetdiff);
		else if(CurrColl.Count > 0) {
			float fmulb = fmul;
			if(Mathf.Abs(rb.velocity.x)*fmul < 1) fmulb = fmul*Mathf.Abs(rb.velocity.x);
			rb.AddForce(-transform.right*rb.mass*fmulb*speed*Mathf.Sign(rb.velocity.x));
		}
    }
}


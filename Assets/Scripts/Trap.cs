using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	public int trapType;
	/*1- Thorn 2-Invisible 3-Fall 4-Hole*/
	public bool activated = false;
	public float gravity;
	public Animator animator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(activated)
		{
			if(trapType==1)
			{
				animator.SetTrigger("activate");
				activated=false;
			}
			else if(trapType==2)
			{
				GetComponent<SpriteRenderer>().enabled=true;
				activated=false;
			}
			else if(trapType==3)
			{
				GetComponent<Rigidbody2D>().gravityScale=10;
				activated=false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
		{
			//mata o player
			Debug.Log("player morto");
		}
    }
}

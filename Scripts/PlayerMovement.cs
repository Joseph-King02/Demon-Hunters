using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


	[HideInInspector]public float playerSpeed = 10.0f; //Placeholder value. TODO: Get this from object containing stats of party members.
	private Rigidbody2D rb; //For storing the Rigidbody of the player.

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	void Update(){
		Vector3 mouseScreen = Input.mousePosition;
		Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
		transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);
		//For facing the mouse. TODO: Add check if using controller, new system.
	}
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal")* playerSpeed, 0.8f),
		Mathf.Lerp(0, Input.GetAxis("Vertical")* playerSpeed, 0.8f));
		//Player movement code.

	}

}

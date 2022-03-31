using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviorScript : MonoBehaviour {
	// void OnCollisionEnter2D(Collision2D collision)
  // {
	// 	Debug.Log("1");
	// 	if (collision.collider.gameObject.tag == "PlayerAttack")
  //     Destroy(gameObject);
  // }
	private Animator SwordAnimator; //Animation compontent (Assigned in Start).

	void Start(){
		PlayAnim();
		// Invoke("DespawnSelf", 0.33f);
		SwordAnimator = GetComponent<Animator>(); // gets animator component.
		// Physics2D.IgnoreCollision(transform.parent.parent.GetComponent<Collider2D>(), GetComponent<Collider2D>()); //Ignores collision with the player.
	}

	void DespawnSelf(){
		Destroy(gameObject);
	}

	public void StopAnim(){
		gameObject.GetComponent<Animator>().enabled = false;
		// SwordAnimator.SetActive(false);
		// SwordAnimator.speed = 0;
	}
	public void PlayAnim(){
		gameObject.GetComponent<Animator>().enabled = true;
		// GetComponent<Animator>().Play("SwordSwing");
	}
}

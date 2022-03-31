using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour {

	private SpriteRenderer PlayerSpriteRenderer; //Stores the objects sprite renderer.
	private Color originalColor;  //Stores the original color for later use with changing color on hit events.
	[HideInInspector]public int health = 100; //TODO: Grab this from a script containing player data.
	private bool Vulnerable = true; //A bool to use with vulnerability.

	void Start(){
		PlayerSpriteRenderer = GetComponent<SpriteRenderer>(); //Stores the sprite.
		originalColor = PlayerSpriteRenderer.color; //Stores original color for later use.
	}
  void OnCollisionEnter2D(Collision2D collision)
  {
		if (collision.collider.gameObject.tag == "Enemy" & Vulnerable == true){
			PlayerSpriteRenderer.color = Color.red;
			//Changes color on hit.
			Vulnerable = false;
			//Invulnerability. (kinda)
			Invoke("ResetColor", 0.7f); //Changes color back after time using invoke.
			health -= 10; //TODO: Grab damage values from enemy's stats.
			Debug.Log(health);
			if (health <= 0){
				Invoke("DespawnSelf", 0.1f);
			}
			//TODO: Enable support for multiple damage types.
		}
  }
	void DespawnSelf(){
		Debug.Log("You are dead!");
		Destroy(gameObject);
	}
	//Collision with objects.
	void ResetColor(){
		Vulnerable = true;
		PlayerSpriteRenderer.color = originalColor; //Changes back to original color.
	}
}

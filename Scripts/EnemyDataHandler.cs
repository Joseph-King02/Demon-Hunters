using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataHandler : MonoBehaviour {
	private SpriteRenderer EnemySpriteRenderer; //Stores the objects sprite renderer.
	private Color originalColor;  //Stores the original color for later use with changing color on hit events.
	[HideInInspector]public int health = 50; //TODO: Grab this from a script containing enemy data, checking by the name of this enemy.
	private bool Vulnerable = true; //A bool to use with vulnerability.

	private EnemyMovement EnemyMovementScript; //The enemy movement script.



	void Start(){
		EnemySpriteRenderer = GetComponent<SpriteRenderer>(); //Stores the sprite.
		originalColor = EnemySpriteRenderer.color; //Stores original color for later use.
		EnemyMovementScript = gameObject.GetComponent(typeof(EnemyMovement)) as EnemyMovement; //Gets the script compontent from the object and sibling element.
	}
  void OnCollisionEnter2D(Collision2D collision)
  {
		if (collision.collider.gameObject.tag == "PlayerAttack" && Vulnerable == true){
			EnemySpriteRenderer.color = Color.gray;
			health -= 10; //TODO: Grab damage values from players stats.
			//Changes color on hit.
			// Vulnerable = false;
			//Invulnerability. (kinda)
			Invoke("ResetColor", 0.3f); //Changes color back after time using invoke.
			if (health <= 0){
				EnemyMovementScript.enemySpeed = 0;
				Invoke("DespawnSelf", 0.4f);
				//Changes speed to 0 and dies.
			}
			//TODO: Get knocked back at speed corresponding to speed of sword.
			//TODO: Enable support for multiple damage types.
		}
  }
	void DespawnSelf(){
		Destroy(gameObject);
		//TODO: Add death animation.
	}
	//Collision with objects.
	void ResetColor(){
		Vulnerable = true;
		EnemySpriteRenderer.color = originalColor; //Changes back to original color.

	}
}

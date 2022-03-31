using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour {
	public Transform SwordPrefab; //Sword prefab (defined in editor)
	private Transform sword; //Sword instance for later use.
	private SwordBehaviorScript SwordScript; //Sword script for later use (Assigned during AttackSpawn).
	// Use this for initialization
	// void Start () {
	//
	// }
	//
	// // Update is called once per frame
	private bool AttackInactive = true;
	void Update () {
		if(Input.GetButtonDown("Attack1")){
			if(sword != null){
				Destroy(sword.gameObject); //Destroys the sword upon attempting to spawn new sword.
			}
			AttackSpawn(); //Calls attack spawn to create new sword.
		}
		if(Input.GetButtonUp("Attack1") && sword != null && SwordScript.GetComponent<Animator>().enabled != true){ //suboptimal, will redo later.
			SwordScript.PlayAnim();
			// SwordScript.Invoke("DespawnSelf", 0.33f);
		} //If the pausesword script has successfully activated while button is still held down, when button picked up, restarts the events for the sword.
		if(Input.GetButtonDown("P"))
		{
				 Debug.Break();
		}
		//This seems to have some level of delay/inconsistency when put in FixedUpdate.
	}
	void AttackSpawn(){
		sword = Instantiate(SwordPrefab, transform.position, transform.rotation) as Transform; //Instantiates the sword from prefab.
		SwordScript = sword.GetComponent(typeof(SwordBehaviorScript)) as SwordBehaviorScript; //Gets the script compontent from the sword.
		sword.transform.parent = gameObject.transform; //Assigns the sword as child of the player.
		// Physics2D.IgnoreCollision(sword.GetComponent<Collider2D>(), transform.parent.transform.GetComponent<Collider2D>()); //Ignores collision with the swrod.
		// Create sword from prefab, moves it to the front of the player.
		Invoke("PauseSword", 0.05f); //Invokes the pause sword script. Delayed to make sure the button is still being held down.
	}

	void PauseSword(){
		if(Input.GetButton("Attack1")){
			SwordScript.StopAnim();
			// SwordScript.CancelInvoke("DespawnSelf");
		}
		//If still held down, stops the current animation for the sword, and the despawning of the sword.
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	[HideInInspector]public int enemySpeed = 1; //Placeholder value. TODO: Get this from object containing stats of enemy. Use int iteratives.
	private Rigidbody2D rb; //For storing the Rigidbody of the enemy.
	public Transform target; //Stores the player object using editor.

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>(); //Gets the selfs rigid body 2d.
	}

	// Update is called once per frame
	void Update () {
			transform.position = Vector3
				.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime); //WTF, this actually works? I've struggled with this type of thing for so long. Solution found at https://gamedev.stackexchange.com/questions/140974/how-do-i-make-game-objects-move-towards-the-player-when-the-player-is-within-a . Not ideal to get player from editor action but w/e.
				//Gets the current position of the enemy, and moves it towards the player position.
			// if (Vector3.Distance(transform.position, target.position) > 1f)
      // {
			// Unnecessary.
      // }
			//Works if current position is more than 1 meter way from player.
			RotateTowards(target.position);
		//For facing the player.
		}

	private void RotateTowards(Vector2 target)
	{
			var offset = 90f;
			Vector2 direction = target - (Vector2)transform.position;
			direction.Normalize();
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
	}//For facing the player.

}

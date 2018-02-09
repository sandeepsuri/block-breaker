using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;

	private Vector3 paddleToBall;
	private bool hasStarted = false;

	// 
	void Start () {
		/*<> are called chevrons; kind of like a filter, saying
		 I only want to find objects that are of Type, w.e I put
		 in the chevrons. Dont have to associate it in the editor */
		paddle = GameObject.FindObjectOfType<Paddle>();		

		paddleToBall = this.transform.position - paddle.transform.position;
		print(paddleToBall);
	}


	void Update () {
		if(!hasStarted) {
		//Lock the ball to the paddle.
		this.transform.position = paddle.transform.position + paddleToBall;

			//Wait for a mouse to press down to launch ball
			if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
				print("Mouse Clicked, Move Ball");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {	
		Vector2 tweak = new Vector2 (Random.Range(0.5f, 0.4f), Random.Range(0.5f, 0.6f)); 

		if(hasStarted) {
		GetComponent<AudioSource>().Play();
		GetComponent<Rigidbody2D>().velocity += tweak;
		}

	}

}
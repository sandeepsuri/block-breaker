using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public bool autoPlay = false;
	public float minX, maxX;

	private Ball ball; 

	void Start() {
		ball = GameObject.FindObjectOfType<Ball>();		
	}

	void Update () {
		//float speed = 10f;
/*			if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {	

					//Moves the block with speed reletive to time							
					transform.position += Vector3.left * speed * Time.deltaTime;	
			}	

			else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { 
					transform.position += Vector3.right * speed * Time.deltaTime;
			}

			else {
					float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;	
					Vector3 paddlePos = new Vector3 (8f, this.transform.position.y, 0f);

					//Boundaries for the paddle
					paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);		
					this.transform.position = paddlePos;
	
		} */

		if (autoPlay == false) {
			MoveWithMouse(); 
		}
		else {
			AutoPlay();
		}
	}

	void AutoPlay() {
		//Automatically plays the game for you
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}

	void MoveWithMouse () {

		/*Gets coordinates for mouse position only on the x axis
		from 0 - 1 thanks to Screen.width */

		/*
		An array of 3(Vector 3) and 4(Vector 4) float values. 
		Vector3 is usually used in 3d space 
		for X,Y and Z values. Vector4 is usually used in shaders 
		for R(ed),G(reen),B(lue),A(lpha) values.

		this.transform.position.y basically means to keep y at the position it started with

		this is the instance of the current script: paddle
		*/
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;	
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);

		//Boundaries for the paddle
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);

		//Make sure this code is after the above code		
		this.transform.position = paddlePos;		
	}

}


using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	// Use this for initialization
/*	void Start () {
		GameObject.DontDestroyOnLoad(gameObject);	/*Static Method: Takes in a game object instance 
													  and makes sure it does not get destroyed on load;
													  gameObject is the Music Player 


	} */

	void Awake() {
		Debug.Log ("Music play Awake " + GetInstanceID());

		if (instance != null) {
			Destroy (gameObject);
			print("Duplicate music player self-destructing");
		}

		else {
			//this is null
			instance = this;	
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	void Start() {
		Debug.Log ("Music Player Start " + GetInstanceID());

	}

	// Update is called once per frame
	void Update () {
	
	}
}

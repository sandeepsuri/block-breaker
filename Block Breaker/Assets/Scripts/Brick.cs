using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	private LevelManager levelManager;
	private int timesHit;
	private int maxHits;

	//boolean called is breakable to see if block under that tag
	private bool isBreakable;	

	public GameObject smoke; 
	public AudioClip crack;
	public AudioClip destroyed; 
	public static int breakableCount = 0;


	//Changes block damage as ball hits it
	public Sprite[] hitSprites;		


	void Start () {
		isBreakable = (this.tag == "Breakable");		
		//Keep track of breakable bricks; if breakeable, increment by 1

		if (isBreakable) {
			breakableCount++;
		}

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	

	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col) {	
		AudioSource.PlayClipAtPoint (crack, transform.position);

		//if block is tagged as Breakable, then it will break
		if (isBreakable) {									
			HandleHits();
		}
	}

	void HandleHits() {
		timesHit = timesHit + 1;
		maxHits = hitSprites.Length + 1;

		if (timesHit >= maxHits) {
			//Decrease breakableCount just before we destroy it

			breakableCount--;
			//Msg the level manager letting it know the brick has been destroyed
			Debug.Log(breakableCount);
			levelManager.BrickDestroyed();
			Destroy(gameObject); 
			puffSmoke();

			//Plays different sound when brick is destroyed
			AudioSource.PlayClipAtPoint (destroyed, transform.position);



		}
		else {
			LoadSprites();
		}
	}

	//Release smoke every time brick is destroyed
	void puffSmoke() {
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor =  gameObject.GetComponent<SpriteRenderer>().color;
        }

	void LoadSprites() {
		//Starts counting at 0 therefore need the index to be timesHit - 1
		int spriteIndex = timesHit - 1;		

		//add if b/c if there is an error, it wont load an empty brick
		if (hitSprites[spriteIndex] != null) {		
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
				/* this meaning the brick, the get component gets us the the Sprite renderer section in unity in the
				insepctor and the element we want in the inspector is sprite
				*/
			}
		else {
			Debug.LogError("Brick sprite missing");

		}


	}

}
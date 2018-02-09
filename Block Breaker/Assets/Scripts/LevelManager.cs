using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	/*Want LevelManager to say Load a new level
	string name is loading the name of the level
	*/
	public void loadLevel(string name) {		
		//Log it out to the console to make sure it has been called properly				

		Debug.Log("Level load requested for: " + name);		
		//Loads the level by its name or index.	
		Brick.breakableCount = 0;
		Application.LoadLevel(name);							
	}

	public void confirmQuit(string name) {			
		//Goes to Start Menu

		Debug.Log("Quitting Game");		
		Application.Quit();
	}

	public void LoadNextLevel() {
		//Loads Next level from the build settings

		Application.LoadLevel(Application.loadedLevel + 1);	
	}

	public void BrickDestroyed() {
		//Loads next level once all bricks have been destroyed

		if (Brick.breakableCount <= 0) {
			LoadNextLevel();
		}

	}

}
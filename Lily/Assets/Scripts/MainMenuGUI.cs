using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPlayButton() {
        Debug.Log("Play Button pressed");
		// Load the first scene in the game
}
	public void OnInstructionsButton() {
        Debug.Log("Instructions Button pressed");
        // Load the instructions menu for the game
    }
}